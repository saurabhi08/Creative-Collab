using Microsoft.AspNetCore.Mvc;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductService _productService;

        public StoreController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Displays a list of products.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        /// <summary>
        /// Displays details for a single product.
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// Displays products filtered by department.
        /// </summary>
        public async Task<IActionResult> ByDepartment(int id)
        {
            var products = await _productService.GetProductsByDepartmentAsync(id);
            ViewData["Title"] = "Products by Department";
            return View("Index", products);
        }

        /// <summary>
        /// Displays products filtered by aisle.
        /// </summary>
        public async Task<IActionResult> ByAisle(int id)
        {
            var products = await _productService.GetProductsByAisleAsync(id);
            ViewData["Title"] = "Products by Aisle";
            return View("Index", products);
        }
    }
}

