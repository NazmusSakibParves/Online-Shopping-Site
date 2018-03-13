using OnlineShopping.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Bll.Concrete
{
    public class FormsAuthentication : InterfaceAdmistrator
    {
        private readonly EFDbContext context = new EFDbContext();
        public bool Authenticate(string username, string password)
        {
            var result = context.Admins.FirstOrDefault(a => a.UserID == username && a.Password == password);
            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
