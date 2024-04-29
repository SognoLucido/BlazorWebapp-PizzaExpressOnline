using Microsoft.EntityFrameworkCore;
using Pizzaisgood.Model;

namespace Pizzaisgood.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Orderlistdb> Orderlistdbz { get; set; }

        public DbSet<Userpaymentinfo> Userpayment { get; set; }


        public DbSet<DataitemsModel> Dataitems { get; set; }
        
        public DbSet<BillingAddress> BillingAddresses { get; set; }




    }







}
