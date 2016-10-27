using System.ComponentModel.DataAnnotations;

namespace GloboMartDataAccessService.Models
{
    public class Product
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
