using System;
using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.ThingIDo
{
    public class CreateOrEditThingIDoViewModel
    {
        #region Properties
        public long ID { get; set; }

        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }


        [Range(4, 12, ErrorMessage = "مقدار وارد شده باید بین 4 تا 12 باشد.")]
        public int ColumnLg { get; set; }


        public int Order { get; set; }

        #endregion

    }
}
