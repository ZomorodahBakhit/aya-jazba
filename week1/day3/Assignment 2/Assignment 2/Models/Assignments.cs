using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2.Models;

namespace Uni2.Models
{
    internal class Assignments
    {
        public int AssignmentId { get; set; }

        public int CourseId { get; set; }

        public string AssignmentTitle { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Weight { get; set; }

        public int MaxGrade { get; set; }

        public DateTime DueDate { get; set; }

        
        public Courses Course { get; set; } = null!;

        
        public ICollection<Comments> Comments { get; set; }
            = new List<Comments>();

        // Öğrencilerin bu ödevden aldığı notlar
        public ICollection<Grades> Grades { get; set; }
            = new List<Grades>();
    }
}
