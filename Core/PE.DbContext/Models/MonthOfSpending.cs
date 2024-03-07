using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class MonthOfSpending
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int YearOfMonth { get; set; }

        public string MonthName { get; set; }
    }
}
