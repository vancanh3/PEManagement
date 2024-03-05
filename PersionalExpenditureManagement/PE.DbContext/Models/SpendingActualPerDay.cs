using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class SpendingActualPerDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double TotalSpedingAmount { get; set; }

        [ForeignKey("MonthOfSpendingId")]
        public MonthOfSpending MonthOfSpending { get; set; }
        public int MonthOfSpendingId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
