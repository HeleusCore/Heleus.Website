using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Heleus.Website.Controllers
{
    public class NoteController : Controller
    {
        readonly static AppInfo AppInfo = AppInfo.Note;
        readonly IWebHostEnvironment _hostingEnvironment;

        public NoteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/note")]
        public IActionResult Index()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/note/downloads")]
        public IActionResult Downloads()
        {
            return View(new AppViewModel(AppInfo, _hostingEnvironment));
        }

        [Route("/note/request/{*url}")]
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
