using Microsoft.EntityFrameworkCore;
using PersionalExpenditureManagement.PE.DbContext.Models;

namespace PersionalExpenditureManagement.PE.DbContext
{
    public class PEDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PEDbContext(DbContextOptions<PEDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<AmountPerCategory> AmountPerCategorys { get; set; }
        public virtual DbSet<AmountPerMonthDetail> AmountPerMonthDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<CurrentActualCashAmount> CurrentActualCashAmounts { get; set; }
        public virtual DbSet<MonthOfSpending> MonthOfSpendings { get; set; }
        public virtual DbSet<SpendingActualPerDay> SpendingActualPerDays { get; set; }
        public virtual DbSet<SpendingByDay> SpendingByDays { get; set; }
        public virtual DbSet<SpendingCategory> SpendingCategorys { get; set; }
        public virtual DbSet<TotalAmountCategoryPerMonth> TotalAmountCategoryPerMonths { get; set; }
        public virtual DbSet<UserSpendingPerMonth> UserSpendingPerMonths { get; set; }
        public virtual DbSet<WithdrawHistory> WithdrawHistorys { get; set; }

        public virtual DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }
    }
}
