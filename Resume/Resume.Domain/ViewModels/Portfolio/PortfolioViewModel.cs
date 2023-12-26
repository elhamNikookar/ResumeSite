using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Portfolio
{
    public class PortfolioViewModel
    {
         public long ID { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public int Order { get; set; } 
        public string PortfolioCategoryTitle { get; set; }

    }
}
