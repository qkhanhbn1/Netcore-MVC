using Microsoft.AspNetCore.Mvc;
using SS03.Models;

namespace SS03.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Quần Áo" },
                new Category { Id = 2, Name = "Túi Xách" },
                new Category { Id = 3, Name = "Đồng Hồ" },
                new Category { Id = 4, Name = "Ti Vi" },
                new Category { Id = 5, Name = "Tủ Lạnh" },
                new Category { Id = 6, Name = "Máy Bơm" },
                new Category { Id = 7, Name = "Quạt Điện" },
                new Category { Id = 8, Name = "Lò Sưởi" }
            };
        
            List<Product> products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    SanPham = "Bộ đồ chơi cho trẻ em nam",
                    Giacu = 50000,
                    Giamoi = 35000,
                    Avatar=Url.Content("~/images/product/1.jpg"),
                    Mota = "đồ bơi",
                    Trangthai ="Còn hàng",
                    Ngaydang = new DateTime(2024,11,11)
                },
                new Product()
                {
                    Id = 2,
                    SanPham = "Bộ đồ chơi cho trẻ em nữ",
                    Giacu = 50000,
                    Giamoi = 35000,
                    Mota = "đồ bơi",
                    Avatar=Url.Content("~/images/product/3.jpg"),
                    Trangthai ="Còn hàng",
                    Ngaydang = new DateTime(2024,11,11)
                },
                new Product()
                {
                    Id = 3,
                    SanPham = "Bộ đồ chơi cho trẻ em 3-5 tuổi",
                    Giacu = 50000,
                    Giamoi = 35000,
                    Mota = "đồ bơi",
                    Avatar=Url.Content("~/images/product/3.jpg"),
                    Trangthai ="Còn hàng",
                    Ngaydang = new DateTime(2024,11,11)
                },
            };
            ViewBag.Categories = categories;
            ViewBag.Products = products;
            return View();
            
        }
        [Route("chi-tiet-san-pham",Name ="Chitietsanpham")]
        public IActionResult Chitietsanpham(int id)
        {
            List<Product> products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    SanPham = "Bộ đồ chơi cho trẻ em nam",
                    Giacu = 50000,
                    Giamoi = 35000,
                    Avatar=Url.Content("~/images/product/1.jpg"),
                    Mota = "đồ bơi",
                    Trangthai ="Còn hàng",
                    Ngaydang = new DateTime(2024,11,11)
                },
                new Product()
            {
                Id = 2,
                SanPham = "Bộ đồ chơi cho trẻ em nữ",
                Giacu = 50000,
                Giamoi = 35000,
                Mota = "đồ bơi",
                Avatar = Url.Content("~/images/product/3.jpg"),
                Trangthai = "Còn hàng",
                Ngaydang = new DateTime(2024, 11, 11)
            },
                new Product()
            {
                Id = 3,
                SanPham = "Bộ đồ chơi cho trẻ em 3-5 tuổi",
                Giacu = 50000,
                Giamoi = 35000,
                Mota = "đồ bơi",
                Avatar = Url.Content("~/images/product/3.jpg"),
                Trangthai = "Còn hàng",
                Ngaydang = new DateTime(2024, 11, 11)
            },
            };
            Product product = products.FirstOrDefault(ac => ac.Id == id);
            ViewBag.product = product;
            return View();
        }
    }
}
