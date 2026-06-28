using Uni2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni2.Models
{
    internal class Comments
    {
        public int CommentId { get; set; }

        
        public int AssignmentId { get; set; }

        
        public int CreatedByUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CommentContent { get; set; }

        // Navigation properties
        public Assignments Assignment { get; set; } = null!;

        public Users CreatedByUser { get; set; } = null!;
    }
}
