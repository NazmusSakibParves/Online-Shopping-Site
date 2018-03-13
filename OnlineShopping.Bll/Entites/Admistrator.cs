using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Bll.Entites
{
    public class Admistrator
    {
        [Key]
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
