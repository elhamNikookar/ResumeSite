using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.Models
{
    public class CustomerFeedback
    {
        [Key]
        public long ID { get; set; }

        public string Avatar { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int Order { get; set; } = 0;

    }
}
