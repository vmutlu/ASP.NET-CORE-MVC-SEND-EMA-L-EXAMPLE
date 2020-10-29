using ExampleEmail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ExampleEmail.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(Contact contact)
        {
            var body = new StringBuilder();
            body.AppendLine("Mesajın İçerigi Buraya Doldurulur");
            body.AppendLine("Name" + contact.Name);
            body.AppendLine("Email"+contact.Email);
            body.AppendLine("Message"+contact.Message);

            Mail.SendMail(body.ToString());

            return View();            
        }
    }
}
