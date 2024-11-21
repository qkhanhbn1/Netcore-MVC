using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string Image { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
