using System;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Heleus.Website.Controllers
{
    public class ErrorController : Controller
    {
        readonly IWebHostEnvironment _hostingEnvironment;

        public ErrorController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(_hostingEnvironment) { Code = 404 });
        }

        [Route("/error/{code:int}")]
        public IActionResult Error(int code)
        {
            return View(new ErrorViewModel(_hostingEnvironment) { Code = code });
        }
    }
}
