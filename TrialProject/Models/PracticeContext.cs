using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrialProject.Entities;
using TrialProjectEntities;

namespace TrialProject
{
    public class PracticeContext : DbContext
    {

        public PracticeContext()
        {

        }

        public PracticeContext(DbContextOptions<PracticeContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
           optionsBuilder.UseSqlServer(@"Server=XIPL9380\SQLEXPRESS;Database=WebAPIDatabase;Trusted_Connection=True;");
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
     
        public DbSet<Address> Addresses { get; set; }
    
      
    }

}
