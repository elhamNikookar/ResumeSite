using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.ViewComponent
{
    public class SideBarViewModel
    {
        public List<SocialMediaViewModel> SocialMedias { get; set; }
        public InformationViewModel Information { get; set; }
    }
}
