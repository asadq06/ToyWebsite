using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }


        public virtual ICollection<Cart> cart { get; set; }

    }
}