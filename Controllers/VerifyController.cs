using System;
using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Heleus.Website.Controllers
{
    public class VerifyController : Controller
    {
        readonly static AppInfo AppInfo = AppInfo.Verify;
        readonly IWebHostEnvironment _hostingEnvironment;

        public VerifyController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/verify")]
        public IActionResult Index()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/verify/downloads")]
        public IActionResult Downloads()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/verify/request/{*url}")]
        public IActionResult AppRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
                return NotFound();

            var request = url.Split('/')[0];
            if (!AppInfo.IsValidRequest(request))
                return NotFound();

            return View("Request", new AppViewModel(AppInfo, _hostingEnvironment) { RequestUrl = url });
        }
    }
}
