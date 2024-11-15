using System.ComponentModel.DataAnnotations;

namespace Lesson04Lab.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Giá")]
        public int Price { get; set; }
        [Display(Name = "Giảm giá")]
        public int SalePrice { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Loại")]
        public byte CategoryId { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        
    }
}
