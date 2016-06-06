using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class Cart
    {
        [Key]
        public int cartID { get; set; }
        public int itemID { get; set; }
        public int userID { get; set; }

        public virtual Item item { get; set; }
        public virtual User user { get; set; }

    }
}