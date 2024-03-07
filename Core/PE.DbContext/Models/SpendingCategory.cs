using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class SpendingCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
