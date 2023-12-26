using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Portfolio
{
    public class PortfolioCategoryViewModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Order { get; set; } 
    }
}
