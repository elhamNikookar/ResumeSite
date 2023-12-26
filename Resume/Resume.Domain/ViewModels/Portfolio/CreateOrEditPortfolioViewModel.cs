using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.ViewModels.Portfolio
{
    public class CreateOrEditPortfolioViewModel
    {
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

        [NotMapped]
        public List<PortfolioCategoryViewModel> PortfolioCategories { get; set; }
    }
}
