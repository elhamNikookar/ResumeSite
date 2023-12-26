using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.CustomerLogo
{
    public class CreateOrEditCustomerLogoViewModel
    {
        public long ID { get; set; }
        public string Logo { get; set; }
        public string LogoAlt { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
    }
}
