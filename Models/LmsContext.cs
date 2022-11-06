using Microsoft.EntityFrameworkCore;

namespace LMSProject.Models
{
    public class LmsContext : DbContext
    {
        public LmsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<UserLoan> UserLoans { get; set; }
        public DbSet<LoanDetails> LoanDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

/*
            modelBuilder.Entity<UserDetails>().HasData(

                  new UserDetails
                  {
                        Id = 101,
                      First_Name = "Vaibhav",
                      Last_Name ="Gangele",
                      Address = "Mahal Road",
                      Phone_No = 123456,
                      City = "chhatarpur",
                      District="chhatarpur",
                      UserName = "vbhv"
                  });
            modelBuilder.Entity<UserLoan>().HasData(
                  new UserLoan
                  {
                      Id = 101,
                       LoanNo = 68,
                       LoanStatus = "Pending" ,
                       UserId = 101 ,
                       LoanDetails_Id = 201
                  });

            modelBuilder.Entity<LoanDetails>().HasData(
                  new LoanDetails
                  {
                      LoanId = 201,
                      Amount = 20000.00f,
                      DateTime = DateTime.ParseExact("20/10/2022 02:45:00", "dd/MM/yyyy HH:mm:ss", null),
                      LoanType = "HomeLoan",
                      UserName = "vbhv"
                  }) ;*/
        }
                
    }
}
