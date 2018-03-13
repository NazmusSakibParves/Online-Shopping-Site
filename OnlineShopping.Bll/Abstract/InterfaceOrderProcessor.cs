using OnlineShopping.Bll.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Bll.Abstract
{
    public interface InterfaceOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shipping);
    }
}
