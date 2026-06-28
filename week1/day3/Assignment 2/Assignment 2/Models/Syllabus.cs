using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni2.Models
{
    internal class Syllabus
    {
        public int SyllabusId { get; set; }

        
        public int CourseId { get; set; }

        public string Content { get; set; } = null!;

        
        public Courses Course { get; set; } = null!;
    }
}
