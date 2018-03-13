using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Bll.Abstract
{
    public interface InterfaceAdmistrator
    {
        bool Authenticate(string username, string password);
        bool Logout();
    }
}
