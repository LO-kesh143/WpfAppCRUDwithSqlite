using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppCRUD.Data
{
    public class ProductDbContext : DbContext
    {
        #region Constructor
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion 

        #region Public properties
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private static Product[] GetProducts()
        {
            return new Product[]
            {
                new Product{ Id=1, Name="TShirt", Description="Blue Color XL", Price=2.99, Unit =11},
                new Product{ Id=2, Name="Shirts", Description="Blue Formal L", Price=12.99, Unit =3},
                new Product{ Id=3, Name="Socks", Description="Wollen", Price=5.00, Unit =2},
                new Product{ Id=4, Name="Shoose", Description="Red Color 8", Price=2.99, Unit =4}
            };
        }
        #endregion
    }
}
