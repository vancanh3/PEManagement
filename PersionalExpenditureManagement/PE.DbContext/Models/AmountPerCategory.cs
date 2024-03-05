using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class AmountPerCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double AmountExpected { get; set; }

        [ForeignKey("SpendingCategoryId")]
        public int SpendingCategoryId { get; set; }
        public SpendingCategory SpendingCategory { get; set; }
    }
}
