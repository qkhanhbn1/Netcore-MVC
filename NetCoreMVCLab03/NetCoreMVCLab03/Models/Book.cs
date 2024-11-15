using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetCoreMVCLab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image="~/images/products/1.jpg",
                    Price=200000,
                    Sumary="",
                    TotalPage=250,

                },
                new Book()
                {
                    Id = 2,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image="~/images/products/4.jpg",
                    Price=300000,
                    Sumary="",
                    TotalPage=250,

                },
                new Book()
                {
                    Id = 3,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image="~/images/products/2.jpg",
                    Price=400000,
                    Sumary="",
                    TotalPage=250,

                },
                new Book()
                {
                    Id = 4,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image="~/images/products/3.jpg",
                    Price=500000,
                    Sumary="",
                    TotalPage=250,

                },
            };
            return books;
        }

        public Book GetBookById (int id)
        {
            Book book  = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="1",Text="Nam Cao1"},
            new SelectListItem{Value="2",Text="Nam Cao2"},
            new SelectListItem{Value="3",Text="Nam Cao3"},
            new SelectListItem{Value="4",Text="Nam Cao4"},
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="1",Text="Truyện tranh"},
            new SelectListItem{Value="2",Text="Văn học đương đại"},
            new SelectListItem{Value="3",Text="Phật học phổ thông"},
            new SelectListItem{Value="4",Text="Truyện cười"},
        };

    }
}
