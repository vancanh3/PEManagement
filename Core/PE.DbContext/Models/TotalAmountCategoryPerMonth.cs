using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class TotalAmountCategoryPerMonth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double TotalAmount { get; set; }

        [ForeignKey("SpendingCategoryId")]
        public SpendingCategory SpendingCategory { get; set; }
        public int SpendingCategoryId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("MonthOfSpendingId")]
        public MonthOfSpending MonthOfSpending { get; set; }
        public int MonthOfSpendingId { get; set; }
    }
}
