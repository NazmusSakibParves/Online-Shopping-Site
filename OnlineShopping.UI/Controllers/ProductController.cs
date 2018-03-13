using OnlineShopping.Bll.Abstract;
using OnlineShopping.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly InterfaceProductRepository repository;
        public int PageItem = 5;
        public ProductController(InterfaceProductRepository repo) {
            repository = repo;
        }
        public ViewResult ProductList(string category, int page = 3) {
            ProductListViewModel model = new ProductListViewModel {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageItem)
                .Take(PageItem),
                PageInfo = new PageInfo() {
                    CurrentPage = page,
                    ItemsPerPage = PageItem,
                    TotalItems = category == null ?
                                 repository.Products.Count() :
                                 repository.Products.Where(p => p.Category == category).Count() 
                },

                CurrentCategory = category
            };

            return View(model);

        }
    }
}