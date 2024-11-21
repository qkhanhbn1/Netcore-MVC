using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150, ErrorMessage = "Tên giới hạn 150 kí tự")]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public float Price { get; set; }

        public byte SalePrice { get; set; }
        public byte Status { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả giới hạn 1000 kí tự")]
        [Column(TypeName = "ntext")]
        public string Descriptions { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm không được để trống")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // Đổi sang `int` nếu `Category.Id` là kiểu `int`

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Gán giá trị mặc định là ngày hiện tại

        public Category Category { get; set; }
    }
}
