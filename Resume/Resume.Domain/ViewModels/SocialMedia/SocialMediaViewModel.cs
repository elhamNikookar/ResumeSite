using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.SocialMedia
{
    public class SocialMediaViewModel
    {
        public long ID { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; } = 0;

    }
}
