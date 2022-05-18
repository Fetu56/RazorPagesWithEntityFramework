using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entity()
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    
            //    User user1 = new User { UserName = "Tom", Age = 33, Password = "b123" };
            //    User user2 = new User { UserName = "Alice", Age = 26, Password = "b123" };
            //    
            //    db.Users.AddRange(user1, user2);
            //    db.SaveChanges();
            //}
            List<User> users = new List<User>();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.ToList().ForEach(x => x.Age++);
                db.SaveChanges();
                users = db.Users.ToList();
            }
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}