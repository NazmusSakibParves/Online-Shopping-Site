using OnlineShopping.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Bll.Entites;

namespace OnlineShopping.Bll.Concrete
{
    public class EFProductRepository : InterfaceProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Entites.Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public Product DeleteProduct(int id)
        {
                   
            Product dbEntry = context.Products.Find(id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }

        
    }
}
