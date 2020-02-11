using System;
using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Controllers
{
    public class HeleusController : Controller
    {
        readonly static AppInfo AppInfo = AppInfo.Heleus;
        readonly IWebHostEnvironment _hostingEnvironment;

        public HeleusController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/heleus")]
        public IActionResult Index()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/heleus/downloads")]
        public IActionResult Downloads()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/heleus/request/{*url}")]
        public IActionResult AppRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
                return NotFound();

            var request = url.Split('/')[0];
            if(!AppInfo.IsValidRequest(request))
                return NotFound();

            return View("Request", new AppViewModel(AppInfo, _hostingEnvironment) { RequestUrl = url });
        }
    }
}
