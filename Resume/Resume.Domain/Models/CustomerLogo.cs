using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{
    public class CustomerLogo
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        public string LogoAlt { get; set; }

        [Required]
        public string Link { get; set; }

        public int Order { get; set; } = 0;

    }
}
