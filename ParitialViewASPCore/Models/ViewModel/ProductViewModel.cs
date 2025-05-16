
using System.ComponentModel.DataAnnotations;

namespace ParitialViewASPCore.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Desc { get; set; } = null!;

        public int Price { get; set; }
        [Required]

        public IFormFile Photo { get; set; } = null!;
    }
}
