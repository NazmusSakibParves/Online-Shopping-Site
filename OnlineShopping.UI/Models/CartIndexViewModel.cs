﻿using OnlineShopping.Bll.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.UI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart  { get; set; }
        public string ReturnUrl { get; set; }
    }
}