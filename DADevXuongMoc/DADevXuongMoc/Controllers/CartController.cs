using DADevXuongMoc.Extensions;
using DADevXuongMoc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DADevXuongMoc.Controllers
{
    public class CartsController : Controller, IActionFilter
    {
        private readonly DevXuongMocContext _context;
        private List<Cart> carts = new List<Cart>();
        public CartsController(DevXuongMocContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cartInSession = HttpContext.Session.GetString("My-Cart");
            Console.WriteLine($"Cart in session: {cartInSession}");
            if (cartInSession != null)
            {
                carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            }
            base.OnActionExecuting(context);
        }

        // GET: CartController
        public IActionResult Index()
        {
            float total = 0;
            foreach (var item in carts)
            {
                total += item.Quantity * item.Price;
            }
            ViewBag.total = total;
            return View(carts);
        }

        // GET: CartController/Details/5
        public ActionResult Add(int id)
        {
            if (carts.Any(c => c.Id == id))// nếu sản phẩm này đã có trong giỏ hàng
            {
                carts.Where(c => c.Id == id).First().Quantity += 1; // tăng số lượng

            }
            else // Nếu sản phẩm chưa có trong giỏ hàng, thêm sản phẩm vào giỏ hàng
            {
                var p = _context.Products.Where(x => x.Id == id).DefaultIfEmpty().FirstOrDefault();// tìm sản phẩm cần mua trong bảng sản phẩm
                // tạo mới một sản phẩm để thêm vào giỏ hàng
                var item = new Cart()
                {
                    Id = p.Id,
                    Name = p.Title,
                    Price = (float)p.PriceNew.Value,
                    Quantity = 1,
                    Image = p.Image,
                    Total = (float)p.PriceNew.Value * 1,

                };
                // Thêm sản phẩm vào giỏ hàng
                carts.Add(item);
            }
            //Lưu carts vào session, cần phải chuyển sang dữ liệu json
            HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            return RedirectToAction("Index");
        }

        
        public ActionResult Remove(int id)
        {
            if (carts.Any(c => c.Id == id))
            {
                var item = carts.First(c => c.Id == id);
                carts.Remove(item);
                Console.WriteLine($"Removed item: {JsonConvert.SerializeObject(item)}");
                Console.WriteLine($"Cart after removal: {JsonConvert.SerializeObject(carts)}");
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id, int quantity)
        {
            if (carts.Any(c => c.Id == id))
            {
                // tìm kiếm sản phẩm trong giỏ hnafg và cập nhật lại số lượng mới
                carts.Where(c => c.Id == id).First().Quantity = quantity;
                // lưu carts vào session , cần phải chuyển sang dữ liệu json
                HttpContext.Session.SetString("My-Cart", JsonConvert.SerializeObject(carts));

            }
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("My-Cart");
            return RedirectToAction("Index");
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Orders()
        {
            // Kiểm tra người dùng đã đăng nhập hay chưa
            if (!User.Identity.IsAuthenticated)
            {
                // Chuyển hướng sang trang Login và giữ lại đường dẫn hiện tại để quay lại sau khi đăng nhập
                return RedirectToAction("Login", "Home", new { ReturnUrl = Url.Action("Orders", "Cart") });
            }

            // Lấy thông tin khách hàng từ session
            var sessionData = HttpContext.Session.GetString("Member");
            if (string.IsNullOrEmpty(sessionData))
            {
                // Nếu không có thông tin trong session, đăng xuất và yêu cầu đăng nhập lại
                return RedirectToAction("Logout", "Home");
            }

            var dataMember = JsonConvert.DeserializeObject<Customer>(sessionData);
            ViewBag.Customer = dataMember;

            // Tính tổng tiền
            float total = carts.Sum(item => item.Quantity * item.Price);
            ViewBag.Total = total;

            // Lấy phương thức thanh toán
            var dataPay = _context.PaymentMethods.ToList();
            ViewData["IdPayment"] = new SelectList(dataPay, "Id", "Name", 1);

            return View(carts);
        }

        public async Task<IActionResult> OrderPay(IFormCollection form)
        {
            try
            {
                // Kiểm tra thông tin người dùng từ session
                var sessionData = HttpContext.Session.GetString("Member");
                if (string.IsNullOrEmpty(sessionData))
                {
                    // Nếu không có thông tin đăng nhập, chuyển hướng về trang login
                    return RedirectToAction("Login", "Home");
                }

                var dataMember = JsonConvert.DeserializeObject<Customer>(sessionData);
                if (dataMember == null)
                {
                    // Nếu không tìm thấy thông tin khách hàng, chuyển hướng
                    return RedirectToAction("Login", "Home");
                }

                // Kiểm tra giỏ hàng
                var carts = HttpContext.Session.GetObjectFromJson<List<Cart>>("My-Cart");
                if (carts == null || !carts.Any())
                {
                    ViewBag.OrderErrorMessage = "Giỏ hàng của bạn đang trống!";
                    return RedirectToAction("Index", "Home"); // Hoặc trả về một thông báo lỗi
                }

                // Tính tổng tiền
                decimal total = carts.Sum(item => item.Quantity * (decimal)item.Price);

                // Tạo đối tượng đơn hàng
                var order = new Order
                {
                    NameReciver = form["NameReciver"],
                    Email = form["Email"],
                    Phone = form["Phone"],
                    Address = form["Address"],
                    Notes = form["Notes"],
                    Idpayment = long.TryParse(form["IdPayment"], out long idPayment) ? idPayment : (long?)null,
                    OrdersDate = DateTime.Now,
                    Idcustomer = dataMember.Id,
                    TotalMoney = total,
                    Idorders = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss")
                };

                // Lưu đơn hàng vào cơ sở dữ liệu
                _context.Add(order);
                await _context.SaveChangesAsync();

                // Lấy id của đơn hàng vừa tạo
                var createdOrder = await _context.Orders.OrderByDescending(o => o.Id).FirstOrDefaultAsync();
                if (createdOrder == null)
                {
                    ViewBag.OrderErrorMessage = "Đã xảy ra lỗi khi tạo đơn hàng!";
                    return View();
                }

                // Tạo và lưu chi tiết đơn hàng
                foreach (var cartItem in carts)
                {
                    var orderDetail = new OrdersDetail
                    {
                        Idord = createdOrder.Id,
                        Idproduct = cartItem.Id,
                        Qty = cartItem.Quantity,
                        Price = (decimal)cartItem.Price,
                        Total = (decimal)(cartItem.Price * cartItem.Quantity),
                        ReturnQty = 0
                    };

                    _context.Add(orderDetail);
                }
                await _context.SaveChangesAsync();

                // Xóa giỏ hàng trong session
                HttpContext.Session.Remove("My-Cart");

                // Trả về trang xác nhận thành công
                ViewBag.OrderSuccessMessage = "Đơn hàng của bạn đã được tạo thành công!";
                return RedirectToAction("OrderSuccess", new { orderId = createdOrder.Id });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                ViewBag.OrderErrorMessage = "Đã xảy ra lỗi trong quá trình xử lý đơn hàng.";
                Console.WriteLine("OrderPay Error: " + ex.Message);
                return View();
            }
        }

    }
}