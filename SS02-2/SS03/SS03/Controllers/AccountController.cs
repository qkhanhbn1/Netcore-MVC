using Microsoft.AspNetCore.Mvc;
using SS03.Models;

namespace SS03.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id =1,Name="Quốc Khánh 1",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,
                    Bio="đây là bio",
                    Birthday= new DateTime(1998,7,15)
                },
                 new Account()
                {
                    Id =2,Name="Quốc Khánh 2",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,
                    Bio="đây là bio",
                    Birthday= new DateTime(1998,7,15)
                },
                  new Account()
                {
                    Id =3,Name="Quốc Khánh 3",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,
                    Bio="đây là bio",
                    Birthday= new DateTime(1998,7,15)
                },
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id =1,Name="Quốc Khánh 1",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
                 new Account()
                {
                    Id =2,Name="Quốc Khánh 2",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
                  new Account()
                {
                    Id =3,Name="Quốc Khánh 3",
                    Email="anh@gmail.com",
                    Phone="0987654321",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/images/avatar/1.jpg"),
                    Gender=1,Bio="My name is small",
                    Birthday= new DateTime(1998,7,15)
                },
            };
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);
            ViewBag.account = account;
            return View();
        }

    }
}
