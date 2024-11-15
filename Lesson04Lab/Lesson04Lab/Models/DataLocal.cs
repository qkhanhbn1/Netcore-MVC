using System.Security.Policy;

namespace Lesson04Lab.Models
{
    public class DataLocal
    {
        public static List<People> _peoples = new List<People>()
        {
            new People()
            {
                Id = 0,
                Name = "Khanh ",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/1.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=0,
            },
            new People()
            {
                Id = 1,
                Name = "Khanh 1",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/2.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=0,
            },
            new People()
            {
                Id = 2,
                Name = "Khanh 2",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/3.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=1,
            },
            new People()
            {
                Id = 3,
                Name = "Khanh 3",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/4.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=1,
            },
            new People()
            {
                Id = 4,
                Name = "Khanh 4",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/5.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=2,
            },
            new People()
            {
                Id = 5,
                Name = "Khanh 5",
                Email="pham khanhttbn@gmail.com",
                Phone="123456789",
                Address="BN",
                Avatar="~/images/avatar/5.jpg",
                Birthday=Convert.ToDateTime("2003/08/26"),
                Bio="đây là bio",
                Gender=2,
            },
        
        };
        public static List<People> GetPeoples()
        {
            return _peoples;
        }
        public static People? GetPeopleById(int id)
        {
            var people = _peoples.FirstOrDefault(x => x.Id == id);
            return people;
        }
    }
}
