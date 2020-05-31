using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SecondTask.Models
{

    public class ApplicationContext : IdentityDbContext<BankUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            for (int i = 0; i < 10; i++)
            {
                var user = new BankUser()
                {
                    Email = $"user{i}@user.ma",
                    NormalizedEmail = $"user{i}@user.ma",
                    Id = i.ToString(),
                    UserName = $"user {i}",
                    Amount = 1000,

                };
                user.PasswordHash = new PasswordHasher<BankUser>().HashPassword(user, "password");
                modelBuilder.Entity<BankUser>().HasData(user);
            }




        }

        public virtual DbSet<BankUser> BankUsers { get; set; }
        public virtual DbSet<BankUserTransaction> BankUserTransactions { get; set; }

    }

}
