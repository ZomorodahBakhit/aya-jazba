using Uni2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni2.Models
{
    internal class Users
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Role { get; set; } = null!;

        
        public ICollection<Courses> CoursesTaught { get; set; }
            = new List<Courses>();

        public ICollection<Comments> Comments { get; set; }
            = new List<Comments>();

       
        public ICollection<Grades> Grades { get; set; }
            = new List<Grades>();
    }
}

