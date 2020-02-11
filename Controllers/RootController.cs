using System;
using Microsoft.AspNetCore.Mvc;
using Heleus.Website.Models;
using Microsoft.AspNetCore.Hosting;
using Heleus.Website.Downloads;
using System.IO;

namespace Heleus.Website.Controllers
{
    public class RootController : Controller
    {
        readonly IWebHostEnvironment _hostingEnvironment;

        public RootController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/datalicence")]
        public IActionResult DataLicence()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/faq")]
        public IActionResult FAQ()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/whitepaper")]
        public IActionResult Whitepaper()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View(new RootViewModel(_hostingEnvironment));
        }

        [Route("/refreshdownloads")]
        public IActionResult RefreshDownloads()
        {
            DownloadsScheduler.ForceRefresh();
            return Redirect("/");
        }

        [Route("/downloadfile/{filename}")]
        public IActionResult DownloadFile(string filename)
        {
            var filepath = DownloadsScheduler.GetFilePath(filename);
            if (filepath != null)
            {
                return PhysicalFile(filepath, "application/octet-stream");
            }

            return NotFound();
        }

        [Route("/storelink/{app}/{os}")]
        public IActionResult DownloadFile(string app, string os)
        {
            var appInfo = AppInfo.GetAppInfo(app);
            if(app != null)
            {
                var redirect = appInfo.GetStoreLink(os);
                if(redirect != null)
                    return Redirect(redirect);
            }

            return NotFound();
        }

        [Route("/blog")]
        public IActionResult Blog()
        {
            return Redirect("https://medium.com/@HeleusCore");
        }

        [Route("/medium")]
        public IActionResult Medium()
        {
            return Redirect("https://medium.com/@HeleusCore");
        }

        [Route("/github")]
        public IActionResult Github()
        {
            return Redirect("https://github.com/HeleusCore/");
        }

        [Route("/facebook")]
        public IActionResult Facebook()
        {
            return Redirect("https://www.facebook.com/HeleusCore/");
        }

        [Route("/twitter")]
        public IActionResult Twitter()
        {
            return Redirect("https://twitter.com/HeleusCore");
        }

        [Route("/instagram")]
        public IActionResult Instagram()
        {
            return Redirect("https://www.instagram.com/heleuscore/");
        }

        [Route("/reddit")]
        public IActionResult Reddit()
        {
            return Redirect("https://reddit.com/r/HeleusCore/");
        }
    }
}
