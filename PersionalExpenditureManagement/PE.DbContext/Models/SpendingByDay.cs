﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersionalExpenditureManagement.PE.DbContext.Models
{
    public class SpendingByDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateOfSpending { get; set; }

        public double AmountSpending { get; set; }

        [ForeignKey("MonthOfSpendingId")]
        public MonthOfSpending MonthOfSpending { get; set; }
        public int MonthOfSpendingId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("SpendingCategoryId")]
        public SpendingCategory SpendingCategory { get; set; }
        public int SpendingCategoryId { get; set; }
    }
}
