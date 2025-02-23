using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } 
        [Required]  
        public int Amount { get; set; }
        [Required]
        [MaxLength(100)]    
        public string Note { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
