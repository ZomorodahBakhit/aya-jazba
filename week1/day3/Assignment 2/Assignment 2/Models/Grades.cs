using Uni2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni2.Models
{
    internal class Grades
    {
        public int GradeId { get; set; }

        
        public int AssignmentId { get; set; }

        
        public int StudentId { get; set; }

        
        public decimal Score { get; set; }

        
        public Assignments Assignment { get; set; } = null!;

        public Users Student { get; set; } = null!;
    }
}
