using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class ProductController(StoreContext _context) : Controller
    {
        public IActionResult ProductList(int page = 1)
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return View(products.ToPagedList(page, 8));
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            ViewBag.Categories = categories;
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }

        public IActionResult First5ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Take(5).ToList();
            return View(values);
        }

        public IActionResult Skip4ProductList()
        {
            var values = _context.Products.Include(x => x.Category).Skip(4).Take(10).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProductWithAttach()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProductWithAttach(Product product)
        {
            var category = new Category { CategoryId = 1 };
            _context.Categories.Attach(category);

            var productValue = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock,
                Category = category
            };

            _context.Products.Add(productValue);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult ProductCount()
        {
            var values = _context.Products.LongCount();
            var lastProduct = _context.Products.OrderBy(x => x.ProductId).Last();
            ViewBag.v2 = lastProduct.ProductName;
            ViewBag.v = values;
            return View();
        }

    }
}
