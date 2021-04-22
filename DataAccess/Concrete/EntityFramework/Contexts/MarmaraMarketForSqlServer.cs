using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class MarmaraMarketForSqlServer:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
