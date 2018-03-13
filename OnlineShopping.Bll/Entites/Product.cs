using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace OnlineShopping.Bll.Entites
{
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Product Name is Required!")]
        public string ProductName { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Description is Required!")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Price is Required!")]
        [Range(0.01, double.MaxValue,ErrorMessage ="Please Enter a Positive Price.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Category is Required!")]
        public string Category { get; set; }
    }
}
