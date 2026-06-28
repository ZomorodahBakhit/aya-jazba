using Uni2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni2.Models
{
    internal class Courses
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = null!;

        public int TeacherId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
        public Users Teacher { get; set; } = null!;

    
        public ICollection<Assignments> Assignments { get; set; }
            = new List<Assignments>();

        
        public Syllabus? Syllabus { get; set; }
    }
}
