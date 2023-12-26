using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models
{
    public class Portfolio
    {

        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Link { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Image { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ImageAlt { get; set; }


        public int Order { get; set; } = 0;


        public long PortfolioCategoryID { get; set; }
        public PortfolioCategory PortfolioCategory { get; set; }

    }


    public class PortfolioCategory
    {

        [Key]
        public long ID { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }


        public int Order { get; set; } = 0;


        ICollection<Portfolio> Portfolios { get; set; }
    }


}
