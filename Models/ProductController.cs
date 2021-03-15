using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Models;

namespace ProductCRUD.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        ProductContext db;
        public ProductController(ProductContext context)
        {
            db = context;
            if (!db.Products.Any())
            {
                db.Products.Add(new Product { Name = "iPhone 12", Company = "Apple", Price = 32499, MadeIn ="USA" });
                db.Products.Add(new Product { Name = "Galaxy S21", Company = "Samsung", Price = 28999, MadeIn = "South Korea" });
                db.Products.Add(new Product { Name = "Pixel 4a", Company = "Google", Price = 11799, MadeIn = "USA" });
                db.Products.Add(new Product { Name = "Mi 11", Company = "Xiaomi", Price = 26999, MadeIn = "China" });
                db.Products.Add(new Product { Name = "Nokia 5310", Company = "Nokia", Price = 1399, MadeIn = "Finland" });
                db.Products.Add(new Product { Name = "Sony Xperia Z5 Dual E6683", Company = "Sony", Price = 5343, MadeIn = "Japan" });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return Ok(product);
        }
    }
}