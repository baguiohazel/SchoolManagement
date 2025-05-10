namespace IDSmarter.Domain.Entities
{
    public class Schedules
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; }

        public ICollection<InstructorDetails>? InstructorDetail { get; set; }
    }
}