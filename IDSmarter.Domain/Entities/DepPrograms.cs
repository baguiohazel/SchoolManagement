using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class DepPrograms
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }

        public ICollection<Students>? Student { get; set; }
        public ICollection<PreRegistrations>? PreRegistration { get; set; }
        public ICollection<InstructorDetails>? InstructorDetail { get; set; }
        public ICollection<Grades>? Grade { get; set; }

    }
}
