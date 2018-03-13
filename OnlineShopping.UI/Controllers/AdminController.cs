using OnlineShopping.Bll.Abstract;
using OnlineShopping.Bll.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        InterfaceProductRepository repository;

        public AdminController(InterfaceProductRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
           return View(repository.Products);
        }
    

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.ProductName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.ProductName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product deletedProduct = repository.DeleteProduct(id);
            if(deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} is Deleted", deletedProduct.ProductName);
            }
            return RedirectToAction("Index");
        }
    }
}