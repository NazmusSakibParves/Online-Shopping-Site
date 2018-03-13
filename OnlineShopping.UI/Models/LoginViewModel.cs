using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopping.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="UserName is Required!")]
        [StringLength(15, MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is Required!")]
        [StringLength(20,MinimumLength =5)]
        public string Password { get; set; }
    }
}