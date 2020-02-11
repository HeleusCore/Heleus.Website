using System;
using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Controllers
{
    public class DocumentationController : Controller
    {
        readonly IWebHostEnvironment _hostingEnvironment;

        public DocumentationController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/documentation")]
        public IActionResult Index()
        {
            return View(new DocumentationViewModel(_hostingEnvironment));
        }
    }
}
