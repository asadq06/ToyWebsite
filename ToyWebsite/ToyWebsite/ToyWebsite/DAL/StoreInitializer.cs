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
                new User {userID = 1, userEmail = "email", userName = "John", userPassword = "123" },
                new User {userID = 2, userEmail = "email", userName = "Asad", userPassword = "123" }
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges(); 
           
            //Categories
            var categories = new List<Category>
            {
                new Category{categoryID=1,categoryName="Stuffed Animals"},
                new Category{categoryID=2,categoryName="Action Figures"},
                new Category{categoryID=3,categoryName="Construction Blocks"},
                new Category{categoryID=4,categoryName="Trains"},
                new Category{categoryID=5,categoryName="Dolls"},
                new Category{categoryID=6,categoryName="Electonics/Video Games"},
                new Category{categoryID=7,categoryName="Outdoor Toys"},
                new Category{categoryID=8,categoryName="Water/Pool Toys"},
                new Category{categoryID=9,categoryName="Puzzles"}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            //Item
            string puzzleCubeDescription = "Match all the colors in this fantastic puzzle game. Will keep you busy and single for hours!";
            var items = new List<Item>
            {
                new Item {itemID = 1, itemName = "Puzzle Cube", itemCost = 10.95f, itemFileName = "cube.png", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=puzzleCubeDescription, categoryID = 9 }

            };
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();

        }
    }
}