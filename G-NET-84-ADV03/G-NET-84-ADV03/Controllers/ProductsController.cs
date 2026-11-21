using G_NET_84_ADV03.Models;
using Microsoft.AspNetCore.Mvc;

namespace G_NET_84_ADV03.Controllers
{
    public class ProductsController : Controller
    {
        //BaseUrl/Controller Name/Action(by default get)
        public IActionResult Index()
        {
            //get all products

            return View();
        }

        #region GetProducts:
        // verb
        //BaseUrl/Controller/FunctionName
        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<Product>()
            {
                new Product {Id = 10,Name="Laptop"},
                new Product {Id = 11,Name="Mobile"},
            };
            return Json(products);
        }
        #endregion
        #region GetProductByID
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            else if(id == 0)
            {
                return RedirectToAction(nameof(Index));

            }
            else if(id<10)
            {
                return NotFound();
            }
            else
            {
                return Json(new Product() { Id = id, Name="Laptop"});
            }
        }
        #endregion
        #region RedirectAction
        [HttpGet]
        public IActionResult RedirectAction()
        {
            return Redirect("https://github.com/tasneem821/G-NET-84-MVC01");
        }
        #endregion
        #region Show File
        [HttpGet]
        public IActionResult FileAction()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/Files/link.pdf");
            return File(fileBytes,"application/pdf", "Sample.pdf");
        }
        #endregion
    }
}
