using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ParitialViewASPCore.Data;
using ParitialViewASPCore.Models;
using ParitialViewASPCore.Models.ViewModel;

namespace ParitialViewASPCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicatinContext Db_Context;
        IWebHostEnvironment env;
        private HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger, ApplicatinContext applicatinContext, IWebHostEnvironment env)
        {
            _logger = logger;
            this.Db_Context = applicatinContext;
            this.env = env;
        }

    
        public IActionResult Privacy()
        {
            return View();
        }
        //[HttpGet]
        public IActionResult ShowCards()
        {
            var prodData = Db_Context.Products.ToList();
            return View(prodData);
        }
        public IActionResult Product()
        {
            return View();
        }
        //[HttpGet]
        public IActionResult Index()
        {
            var prodData = Db_Context.Products.ToList();
            return View(prodData);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel prod)
        {
            string fileName = "";
            if (prod.Photo != null)
            {
                var ext = Path.GetExtension(prod.Photo.FileName);
                var size = prod.Photo.Length;
                if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                {
                    if (size <= 1000000) // 1000000 Bytes = 1Mb
                    {


                        string folder = Path.Combine(env.WebRootPath, "images");
                        fileName = Guid.NewGuid().ToString() + "_" + prod.Photo.FileName;
                        string filePath = Path.Combine(folder, fileName);
                        prod.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        Product p = new Product()
                        {
                            Name = prod.Name,
                            Desc = prod.Desc,
                            Price = prod.Price,
                            ImagePath = fileName
                        };
                        Db_Context.Products.Add(p);
                        Db_Context.SaveChanges();
                        TempData["Success"] = "Product Added.. ";
                        return RedirectToAction("Index"); // kyuki all product mai retreive karooga in Index page pe
                    }
                    else
                    {
                        TempData["Size_Error"] = "Image must be less than 1Mb";

                    }
                }
            }
            else
            {
                TempData["Ext_Error"] = "Only PNG, JGP, JPEG images are allowed.";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
