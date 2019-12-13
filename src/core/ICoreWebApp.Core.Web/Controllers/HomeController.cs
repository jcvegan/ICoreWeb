using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ICoreWeb.Data.Identity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICoreWebApp.Core.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace ICoreWebApp.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<CoreUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<CoreUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           //_userManager.CreateAsync(new CoreUser(){ UserName = "jcvegan", FirstName = "Juan Carlos", LastName = "Vega Neira"}, "#JuCaVeNe191188+").GetAwaiter().GetResult();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
