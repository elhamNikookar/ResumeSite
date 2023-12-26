using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.CustomerFeedback
{
    public class CustomerFeedbackViewModel
    {
        public long ID { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; } 

    }
}
