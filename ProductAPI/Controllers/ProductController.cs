using Microsoft.AspNetCore.Mvc;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public IActionResult Index()
        {
            return View();
        }
    }
}
