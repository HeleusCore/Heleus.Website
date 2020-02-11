using System;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Models
{
    public class RootViewModel : ViewModelBase
    {
        public RootViewModel(IWebHostEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
        }
    }
}
