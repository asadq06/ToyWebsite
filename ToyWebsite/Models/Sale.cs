using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int saleID { get; set; }
        public int itemID { get; set; }
        public float saleDiscount { get; set; }
        public DateTime saleStart { get; set; }
        public DateTime saleEnd { get; set; }

        public virtual Item item { get; set; }
    }
}