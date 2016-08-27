namespace ToyWebsite.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToyWebsite.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ToyWebsite.DAL.StoreContext context)
        {
            if (!context.Users.Any())
            {
                //User
                var users = new List<User>
            {
                new User {userEmail = "email@example.com", userName = "Guest", userPassword = "123456", userConfirmPassword="123456"  }
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

                //Items
                string puzzleCubeDescription = "Match all the colors in this fantastic puzzle game. Will keep you busy and single for hours!";
                string woodenTrainDescription = "Cool wooden train. Will keep your child occupied for hours and is safe for all children.";
                string stuffedElephantDescription = "Fun stuffed elphant. It is really soft and your child will basically fuze to it.";
                string stuffedHippoDescription = "Lovable fun hippo stuffed toy. Definately worth every cent.";
                string buttonDescription = "Press these buttons for days. Remember to drink high caffeine energy drinks because you will be pressing these buttons until your fingers fall off.";
                var items = new List<Item>
                {
                    new Item {itemName = "Puzzle Cube", itemCost = 10.95f, itemFileName = "puzzle.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=puzzleCubeDescription, categoryID = 9 },
                    new Item {itemName = "Wooden Train", itemCost = 34.91f, itemFileName = "cooltrain.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=woodenTrainDescription, categoryID = 4 },
                    new Item {itemName = "Stuffed Elephant", itemCost = 1100.91f, itemFileName = "elephant.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=stuffedElephantDescription, categoryID = 1 },
                    new Item {itemName = "Stuffed Hippo", itemCost = 1100.91f, itemFileName = "hippo.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=stuffedHippoDescription, categoryID = 1 },
                    new Item {itemName = "Buttons", itemCost = 1100.91f, itemFileName = "buttons.jpg", itemQuantitySold = 0, itemQuantityStock = 10, itemDescription=buttonDescription, categoryID = 6 }

                };
                items.ForEach(s => context.Items.Add(s));
                context.SaveChanges();


            }
        }
    }
}
