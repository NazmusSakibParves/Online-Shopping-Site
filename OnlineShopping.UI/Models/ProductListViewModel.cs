using OnlineShopping.Bll.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.UI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}