using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToyWebsite.Models;

namespace ToyWebsite.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("name=StoreContext")
        {
        }


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }


      
    }
}