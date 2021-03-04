using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje classlarını bağlamak(product,customer,..)
    public class NorthwindContext:DbContext                                        // Kütüphanden geldi DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)         // hangi veritabanı ile ilişkilerndireceğimizi belirtiriz => OnConfiguring
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");               // burda bulunan db ye bağlanıyoruz.
        }


        // hangi nesnem hangi nesneye karşılık gelecek bunu Dbset dediğimiz bir nesne ile yapıyoruz
        public DbSet<Product> Products { get; set; }                     // benim product nesnemi veri tabanındaki products ile bağla.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
