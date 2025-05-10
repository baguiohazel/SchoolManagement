namespace IDSmarter.Domain.Entities
{
    public class Deans
    {
        public int Id { get; set; }
        public string DeanName { get; set; }
        public string Email { get; set; }
        public int? AdminId { get; set; }
        public Admins Admin { get; set; }
        public ICollection<Students>? Student { get; set; }
        public ICollection<Instructors>? Instructor { get; set; }
      
    }
}