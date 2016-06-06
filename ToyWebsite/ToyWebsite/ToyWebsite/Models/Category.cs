using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }
        public string categoryName { get; set; }

        public virtual ICollection<Item> item { get; set; }
    }
}