namespace IDSmarter.Domain.Entities
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProgramId { get; set; }
        public int StrandId { get; set; }

        public Students Student { get; set; }
        public DepPrograms Program { get; set; }
        public Strands Strand { get; set; }
    }
}