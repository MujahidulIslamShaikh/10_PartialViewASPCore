

using System.ComponentModel.DataAnnotations;

namespace ParitialViewASPCore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Desc { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImagePath { get; set; } = null!;
    }
}
