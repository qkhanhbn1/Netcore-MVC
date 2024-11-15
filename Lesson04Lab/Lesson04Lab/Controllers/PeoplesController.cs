using Lesson04Lab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson04Lab.Controllers
{
    public class PeoplesController : Controller
    {
       
        public ActionResult Index()
        {
            var _peoples = DataLocal.GetPeoples();
            return View(_peoples);
        }

        
        public ActionResult Details(int id)
        {
            var peoples = DataLocal.GetPeopleById(id);
            return View(peoples);
        }


        public ActionResult Create()
        {
            People people = new People();
            return View(people);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(People model)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\avatar", FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        model.Avatar = "/images/avatar/" + FileName;
                    }
                }

                DataLocal._peoples.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var people = DataLocal.GetPeopleById(id);
            return View(people);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, People model)
        {
            try
            {

                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\avatar", FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        model.Avatar = "/images/avatar/" + FileName;
                    }
                }
                for (int i = 0;i<DataLocal._peoples.Count;i++)
                {
                    if(DataLocal._peoples[i].Id == id)
                    {
                        DataLocal._peoples[i] = model;
                        break;
                    }    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

       
        public ActionResult Delete(int id)
        {
            var peoples = DataLocal.GetPeopleById(id);
            return View(peoples);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, People model)
        {
            try
            {   
                for (int i = 0;i< DataLocal._peoples.Count;i++)
                {
                    if (DataLocal._peoples[i].Id == id)
                    {
                        DataLocal._peoples.RemoveAt(i);
                        break;
                    }    
                }    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
