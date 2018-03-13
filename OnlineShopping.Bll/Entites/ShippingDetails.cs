using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Bll.Entites
{
    public class ShippingDetails
    {
        [Required(ErrorMessage="Name is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Contact Number is Required!")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage ="Address is Required!")]
        public string Address { get; set; }
        [Required(ErrorMessage ="District is Requuired!")]
        public string District { get; set; }
        [Required(ErrorMessage ="Email is Required!")]
        [RegularExpression(@"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$", ErrorMessage = "Please Enter a Valid Email !")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Your Comments or any Notes!")]
        public string Comments { get; set; }
        public bool GiftWrap { get; set; }


    }
}
