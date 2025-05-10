namespace IDSmarter.Domain.Entities
{
    public class InstructorDetails
    {
        public int Id { get; set; }
        public int? ProgramId { get; set; }
        public int? StrandId { get; set; }
        public int? ScheduleId { get; set; }
        public int? PreRegistrationId { get; set; }

        public DepPrograms Program { get; set; }
        public Strands Strand { get; set; }
        public Schedules Schedule { get; set; }
        public PreRegistrations PreRegistration { get; set; }

        public ICollection<Instructors>? Instructor { get; set; }
    }
}