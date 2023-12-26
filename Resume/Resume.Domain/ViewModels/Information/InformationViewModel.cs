using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Information
{
    public class InformationViewModel
    {
        public long ID { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ResumeFile { get; set; }
        public string MapSrc { get; set; }

    }
}
