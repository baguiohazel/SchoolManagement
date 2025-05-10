using System.Diagnostics;

namespace IDSmarter.Domain.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }

        public int PreRegistrationId { get; set; }
        public PreRegistrations PreRegistration { get; set; }
        public int? AdminId { get; set; }
        public Admins Admin { get; set; }
        public int? DeanId { get; set; }
        public Deans Dean { get; set; }
        public int? DepProgramId { get; set; }
        public DepPrograms DepProgram { get; set; }
        public ICollection<Enrollments>? Enrollment { get; set; }
        public ICollection<Grades>? Grade { get; set; }
        public StudentDetails? StudentDetail { get; set; }
    }
}
