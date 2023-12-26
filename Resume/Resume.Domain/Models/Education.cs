using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models
{
    public class Education
    {

        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(4, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
        public string EndDate { get; set; }

        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }

        public int Order { get; set; } = 0;

    }
}
