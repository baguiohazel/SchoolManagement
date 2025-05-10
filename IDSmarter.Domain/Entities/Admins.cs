using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSmarter.Domain.Entities
{
    public class Admins
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string Email { get; set; } 
        public ICollection<Students>? Student { get; set; }
        public ICollection<Instructors>? Instructor { get; set; }
        public ICollection<Deans>? Dean { get; set; }
    }
}
