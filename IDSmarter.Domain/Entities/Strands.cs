namespace IDSmarter.Domain.Entities
{
    public class Strands
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }

        public ICollection<PreRegistrations> PreRegistration { get; set; }
        public ICollection<Grades> Grade { get; set; }
        public ICollection<InstructorDetails> InstructorDetail { get; set; }
    }
}