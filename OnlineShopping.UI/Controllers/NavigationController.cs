using OnlineShopping.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.UI.Controllers
{
    public class NavigationController : Controller
    {
        private InterfaceProductRepository repository;

        public NavigationController(InterfaceProductRepository repo) {

            repository = repo;

        }


        // GET: Navigation
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                                             .Select(x => x.Category)
                                             .Distinct()
                                             .OrderBy(x => x);

                return PartialView(categories);
        }
    }
}