namespace IDSmarter.Domain.Entities
{
    public class Instructors
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
        public string Email { get; set; }
        public int InstructorDetailId { get; set; }
        public InstructorDetails? InstructorDetail { get; set; }
        public int? AdminId { get; set; }
        public Admins Admin { get; set; }
        public int? DeanId { get; set; }
        public Deans Dean { get; set; }
        public ICollection<Courses>? Course { get; set; }
       
    }
}