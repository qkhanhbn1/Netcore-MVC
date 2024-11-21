using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float ProductPrice { get; set; }
        public int ProductSale { get; set; }
        public bool Status { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}
