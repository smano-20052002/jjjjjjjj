namespace LXP.Common.ViewModels
{
    public class MaterialWithCourseListViewModel
    {
        public Guid MaterialId { get; set; }

        public string TopicName { get; set; }

        public string MaterialType { get; set; }

        public string CourseName {get; set;}

        public string Name { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public TimeOnly Duration { get; set; }

        public bool IsActive { get; set; }

        public bool IsAvailable { get; set; }

        public string? CreatedBy { get; set; } = null;

        public DateTime CreatedAt { get; set; }

        public string? ModifiedBy { get; set; } = null;

        public DateTime? ModifiedAt { get; set; } = null;
    }
}
