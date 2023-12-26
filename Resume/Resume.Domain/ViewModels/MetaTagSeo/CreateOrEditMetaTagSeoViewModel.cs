using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.MetaTagSeo
{
    public class CreateOrEditMetaTagSeoViewModel
    {
        public long ID;


        public string Keywords { get; set; } 
        public string Description { get; set; }
        public string Author { get; set; } 
        public int? RefreshTime { get; set; }


        public string OgTitle { get; set; } 
        public string OgDescription { get; set; } 
        public string OgImage { get; set; } 
        public string OgUrl { get; set; } 
        public string OgType { get; set; }
        public string OgLocale { get; set; } 


        public string TwitterUrl { get; set; } 
        public string TwitterTitle { get; set; } 
        public string TwitterDescription { get; set; }
        public string TwitterImage { get; set; } 
    }
}
