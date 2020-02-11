using System;
using Microsoft.AspNetCore.Hosting;

namespace Heleus.Website.Models
{
    public class DocumentationViewModel : ViewModelBase
    {
        public DocumentationViewModel(IWebHostEnvironment hostingEnvironment) : base(hostingEnvironment)
        {
        }
    }
}
