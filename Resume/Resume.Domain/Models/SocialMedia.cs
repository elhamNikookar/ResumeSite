using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models
{
    public class SocialMedia
    {

        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Link { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Icon { get; set; }

        public int Order { get; set; } = 0;

    }
}
