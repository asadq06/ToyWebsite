using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToyWebsite.Models;

namespace ToyWebsite.DAL
{

    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            //Users
            var users = new List<User>
            {
                new User {userEmail = "email@example.com", userName = "Guest", userPassword = "123456" }
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges(); 
           
            //Categories
            var categories = new List<Category>
            {
                new Category{categoryName="Stuffed Animals"},
                new Category{categoryName="Action Figures"},
                new Category{categoryName="Construction Blocks"},
                new Category{categoryName="Trains"},
                new Category{categoryName="Dolls"},
                new Category{categoryName="Electonics/Video Games"},
                new Category{categoryName="Outdoor Toys"},
                new Category{categoryName="Water/Pool Toys"},
                new Category{categoryName="Puzzles"}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            //Item
            string puzzleCubeDescription = "Match all the colors in this fantastic puzzle game. Will keep you busy and single for hours!";
            string woodenTrainDescription = "Cool wooden train. Will keep your child occupied for hours and is safe for all children.";
            var items = new List<Item>
            {
                new Item {itemName = "Puzzle Cube", itemCost = 10.95f, itemFileName = "cube.png", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=puzzleCubeDescription, categoryID = 9 },
                new Item {itemName = "Wooden Train", itemCost = 34.91f, itemFileName = "train.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=woodenTrainDescription, categoryID = 4 }

            };
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

            /*
            var carts = new List<Cart>
            {
                new Cart { userID = 1, itemID = 2  }
            };
            carts.ForEach(s => context.Carts.Add(s));
            context.SaveChanges();
            */
        }
    }
}