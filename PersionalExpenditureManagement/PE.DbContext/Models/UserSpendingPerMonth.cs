using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class UserSpendingPerMonth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MonthOfSpending")]
        public int MonthOfSpendingId { get; set; }
        public MonthOfSpending MonthOfSpending { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("SpendingCategoryId")]
        public SpendingCategory SpendingCategory { get; set; }
        public int SpendingCategoryId { get; set; }
    }
}
