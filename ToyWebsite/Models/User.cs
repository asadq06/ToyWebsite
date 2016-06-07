using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToyWebsite.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        [DisplayName("Username")]
        public string userName { get; set; }
        [DisplayName("Password")]
        public string userPassword { get; set; }
        [DisplayName("Email")]
        public string userEmail { get; set; }


        public virtual ICollection<Cart> cart { get; set; }

    }
}