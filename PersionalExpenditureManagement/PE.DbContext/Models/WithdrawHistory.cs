using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class WithdrawHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime WithdrawDate { get; set; }

        public double WithdrawAmount { get; set; }

        [ForeignKey("BankId")]
        public BankAccount BankAccount { get; set; }
        public int BankId { get; set; }
    }
}
