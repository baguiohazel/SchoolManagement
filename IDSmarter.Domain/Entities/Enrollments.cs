namespace IDSmarter.Domain.Entities
{
    public class Enrollments
    {
        public int Id { get; set; }
        public string StudNum { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int Amount { get; set; }
        public int AmountPaid { get; set; }
        public int Balance => Amount - AmountPaid;
        public DateTime PaymentDate { get; set; }
        public string PaymentReference { get; set; }
        public string Semester { get; set; }
        public int AcademicYear { get; set; }
        public DateTime EnrolledAt { get; set; }

        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? PreRegistrationId { get; set; }

        public Students Student { get; set; }
        public Courses Course { get; set; }
        public PreRegistrations PreRegistration { get; set; }
    }
}