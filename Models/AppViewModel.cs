using System;
using System.Collections.Generic;
using Heleus.Website.Downloads;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Models
{
    public class AppViewModel : ViewModelBase
    {
        public AppInfo AppInfo { get; set; }

        public AppViewModel(AppInfo appInfo, IWebHostEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
            AppInfo = appInfo;

            Title = AppInfo.Fullname;
            PromoHeading = "Heleus Core";
            PromoText = AppInfo.Fullname;
            BrandingUrl = AppInfo.Name;
            BrandingImage = $"{BrandingUrl}/branding.png";
            BrandingIcon = $"{BrandingUrl}/icon.png";
        }
    }
}
