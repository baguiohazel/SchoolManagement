using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IDSmarter.Domain.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? StrandId { get; set; }
        public int? ProgramId { get; set; }

        public Students Student { get; set; }
        public Courses Course { get; set; }
        public Strands Strand { get; set; }
        public DepPrograms DepProgram { get; set; }

        public int PrelimScore { get; set; }
        public int MidtermScore { get; set; }
        public int PrefinalScore { get; set; }
        public int FinalScore { get; set; }

        public double TermAverage => (PrelimScore + MidtermScore + PrefinalScore + FinalScore) / 4;
        
    }
}
