using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Icon { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = null!;
    }
}
