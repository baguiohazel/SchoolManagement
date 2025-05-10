using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class Courses
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public int? InstructorId { get; set; }
        public Instructors Instructor { get; set; }
        public int? ProgramId { get; set; }
        public DepPrograms DepProgram { get; set; }
        public ICollection<Enrollments>? Enrollment { get; set; }
        public ICollection<Grades>? Grade { get; set; }
    }
}
