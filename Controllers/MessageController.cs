using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Heleus.Website.Controllers
{
    public class MessageController : Controller
    {
        readonly static AppInfo AppInfo = AppInfo.Message;
        readonly IWebHostEnvironment _hostingEnvironment;

        public MessageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/message")]
        public IActionResult Index()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/message/downloads")]
        public IActionResult Downloads()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/message/request/{*url}")]
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
