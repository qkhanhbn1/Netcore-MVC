using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Lỗi: tên danh mục vượt quá 100 kí tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Range(0, 255, ErrorMessage = "Trạng thái phải là một giá trị hợp lệ từ 0 đến 255.")]
        public byte Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; } = DateTime.Now;  // Giá trị mặc định là ngày hiện tại

        public ICollection<Product> Products { get; set; } = new List<Product>();  // Khởi tạo danh sách trống
    }
}

