using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        [DisplayName("Confirm Password")]
        [Required]
        [Compare("userPassword",ErrorMessage = "Passwords do not match.")]
        public string userConfirmPassword { get; set; }


        [DisplayName("Email")]
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string userEmail { get; set; }

        //public string? userSalt { get; set; }

        public virtual ICollection<Cart> cart { get; set; }

        

    }


}