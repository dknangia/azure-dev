using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptedData.Models;
using Microsoft.EntityFrameworkCore;

namespace EncryptedData
{
    public class SportsStoreDBContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public SportsStoreDBContext(DbContextOptions<SportsStoreDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().OwnsOne(product => product.JsonData2, builder => { builder.ToJson(); });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SportsStoreDBContext).Assembly);
        }
    }

    internal static class SportsStoreDb
    {
        internal const string SchemaName = "dbo";

        internal static class Tables
        {


            internal const string TableName = "Products";

            internal static class Columns
            {
                internal const string ProductId = "ProductId";
                internal const string Name = "Name";
                internal const string Description = "Description";
                internal const string Price = "Price";
                internal const string Category = "Category";
                internal const string JsonData = "JsonData";
                //internal const string JsonData2 = "JsonData2";
            }
        }

    }
}
