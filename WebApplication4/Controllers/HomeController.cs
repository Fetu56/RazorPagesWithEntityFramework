using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entity()
        {
            using (ApplicationContext db = new ApplicationContext(Configuration))
            {
                db.Products.Add(new Product() {  Description = "desc", Category = new Category() { Name = "lol"}, Cost = 5, ProductName = "lkoasf" });
                db.SaveChanges();
                ViewBag.Product = db.Products.ToList();
                ViewBag.Category = db.Categories.ToList();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OnGetReset()
        {
            using (ApplicationContext db = new ApplicationContext(Configuration))
            {
                db.Products.ToList().Clear();
                db.SaveChanges();
            }
            return RedirectToPage("Entity");
        }
    }
}