using System;
using System.IO;
using System.Threading.Tasks;
using Heleus.Website.Downloads;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Models
{
    public abstract class ViewModelBase
    {
        readonly IWebHostEnvironment _hostingEnvironment;

        protected ViewModelBase(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string BrandingImage
        {
            get;
            set;
        } = "images/branding.png";

        public string BrandingIcon
        {
            get;
            set;
        } = null;

        public string BrandingUrl
        {
            get;
            set;
        } = "";

        public string Title
        {
            get;
            set;
        } = "Heleus Core";

        public string Author
        {
            get;
            set;
        } = "Heleus Core";

        public string Description
        {
            get;
            set;
        } = "Heleus Core";

        public bool FullscreenPromo
        {
            get;
            set;
        } = false;

        public string PromoImage
        {
            get;
            set;
        } = "/images/promo/space.jpg";

        public string PromoHeading
        {
            get;
            set;
        } = string.Empty;

        public string PromoText
        {
            get;
            set;
        } = string.Empty;

        public string PromoTagline
        {
            get;
            set;
        } = string.Empty;

        public bool HasContainerClass
        {
            get;
            set;
        } = false;

        public string ContainerClass => HasContainerClass ? "container" : string.Empty;

        public string RequestUrl { get; set; }

        public Task<string> ReadMarkDownAsync(string path)
        {
            var fileInfo = _hostingEnvironment.WebRootFileProvider.GetFileInfo($"markdown/{path}.md");
            return fileInfo.Exists ? File.ReadAllTextAsync(fileInfo.PhysicalPath) : Task.FromResult(string.Empty);
        }
    }
}
