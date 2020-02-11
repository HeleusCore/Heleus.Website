using System;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Models
{
    public class ErrorViewModel : ViewModelBase
    {
        public ErrorViewModel(IWebHostEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
            PromoImage = "/images/promo/error.jpg";
        }

        public int Code { get; set; }
    }
}