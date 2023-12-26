

namespace Resume.Domain.ViewModels.Education
{
    public class CreateOrEditEducationViewModel
    {
        public long ID { get; set; }

        public string Title { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
    }
}
