using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemID { get; set; }
        public string itemName { get; set; }
        public float itemCost { get; set; }
        public string itemFileName { get; set; }
        public int itemQuantitySold { get; set; }
        public int itemQuantityStock { get; set; }
        public string itemDescription { get; set; }
        public int categoryID { get; set; }

        public virtual Category category { get; set; }
    }
}