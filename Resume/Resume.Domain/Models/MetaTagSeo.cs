using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{
    public class MetaTagSeo
    {
        [Key]
        public long ID { get; set; }


        [Required(AllowEmptyStrings = true)]
        public string Keywords { get; set; } = " ";

        
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; } = " ";

        
        [Required(AllowEmptyStrings = true)]
        public string Author { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public int? RefreshTime { get; set; } = 60;


        [Required(AllowEmptyStrings = true)]
        public string OgTitle { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string OgDescription { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string OgImage { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string OgUrl { get; set; } = " ";



        [Required(AllowEmptyStrings = true)]
        public string OgType { get; set; } = "resume";


        [Required(AllowEmptyStrings = true)]
        public string OgLocale { get; set; } = "fa_IR";



        [Required(AllowEmptyStrings = true)]
        public string TwitterUrl { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string TwitterTitle { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string TwitterDescription { get; set; } = " ";


        [Required(AllowEmptyStrings = true)]
        public string TwitterImage { get; set; } = " ";
       
    }
}
