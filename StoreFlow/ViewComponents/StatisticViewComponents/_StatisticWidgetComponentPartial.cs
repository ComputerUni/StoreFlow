using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.StatisticViewComponents
{
    public class _StatisticWidgetComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _context.Categories.Count();

            ViewBag.productMaxPrice = _context.Products.Max(x => x.ProductPrice);
            ViewBag.productMaxPriceName = _context.Products.OrderByDescending(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();

            ViewBag.productMinPrice = _context.Products.Min(x => x.ProductPrice);
            ViewBag.productMinPriceName = _context.Products.OrderBy(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();

            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);

            var maxStock = _context.Products.OrderByDescending(x => x.ProductStock).Select(x => new { x.ProductName, x.ProductStock }).FirstOrDefault();
            ViewBag.totalMaxSumProductStockName = maxStock?.ProductName;
            ViewBag.totalMaxSumProductStock = maxStock?.ProductStock;

            var minStock = _context.Products.OrderBy(x => x.ProductStock).Select(x => new { x.ProductName, x.ProductStock }).FirstOrDefault();
            ViewBag.totalMinSumProductStockName = minStock?.ProductName;
            ViewBag.totalMinSumProductStock = minStock?.ProductStock;

            ViewBag.avgProductStock = _context.Products.Average(x => x.ProductStock).ToString("N2");
            ViewBag.avgProductPrice = _context.Products.Average(x => x.ProductPrice).ToString("N2");

            ViewBag.totalMaxOrderProductName = _context.Orders.Include(x => x.Product).OrderByDescending(x => x.OrderCount).Select(x => x.Product.ProductName).FirstOrDefault();
            ViewBag.totalMaxOrderProductCount = _context.Orders.OrderByDescending(x => x.OrderCount).Select(x => x.OrderCount).FirstOrDefault();

            ViewBag.biggerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIDIs4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y => y.ProductName).FirstOrDefault();
            ViewBag.stockCountBigger50AndSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();


            ViewBag.orderCount = _context.Orders.Sum(x => x.OrderCount);
            ViewBag.maxCategoryName = _context.Categories.Include(x => x.Products).OrderByDescending(x => x.Products.Average(p => p.ProductPrice)).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.criticalStockCount = _context.Products.Where(x => x.ProductStock < 10).Count();

            return View();
        }
    }
}
