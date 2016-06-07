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
        [Required]
        [MaxLength(32)]
        [MinLength(4)]
        [Index(IsUnique = true)]
        public string userName { get; set; }

        [DisplayName("Password")]
        [Required]
        [MaxLength(32)]
        [MinLength(6)]
        public string userPassword { get; set; }

        [DisplayName("Email")]
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string userEmail { get; set; }


        public virtual ICollection<Cart> cart { get; set; }

    }
}