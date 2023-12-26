
using System.ComponentModel.DataAnnotations;


namespace Resume.Domain.Models
{
    public class ThingIDo
    {
        #region properties
        [Key]
        public long ID { get; set; }

        [MaxLength(50)]
        public string Icon { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(4,12)]
        public int ColumnLg { get; set; } = 6;

        public int Order { get; set; } = 0;

        #endregion


    }
}
