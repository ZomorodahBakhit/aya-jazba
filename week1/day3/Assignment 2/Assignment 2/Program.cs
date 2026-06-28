
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2;
using Uni2.Models;

namespace Uni2 
{
    internal class Program
    {
        
    static void Main(string[] args)
        {
            using var db = new UniversityDbContext();
            if (!db.Users.Any())
            {
                var users = new List<Users>
                {
                    
                    new Users
                    {
                        UserName = "aya.jazba",
                        FirstName = "Aya",
                        LastName = "Jazba",
                        EmailAddress = "student1@gmail.com",
                        PhoneNumber = "0000000001",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "fawzy.sukkar",
                        FirstName = "Fawzy",
                        LastName = "Sukkar",
                        EmailAddress = "student2@university.com",
                        PhoneNumber = "0000000002",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "hiba.jazba",
                        FirstName = "Hiba",
                        LastName = "Jazba",
                        EmailAddress = "student3@university.com",
                        PhoneNumber = "0000000003",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "marah.aljumaat",
                        FirstName = "Marah",
                        LastName = "Aljumaat",
                        EmailAddress = "student4@university.com",
                        PhoneNumber = "0000000004",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "masa.hammoud",
                        FirstName = "Masa",
                        LastName = "Hammoud",
                        EmailAddress = "student5@university.com",
                        PhoneNumber = "0000000005",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "mehyar.khuder",
                        FirstName = "Mehyar",
                        LastName = "Khuder",
                        EmailAddress = "student6@university.com",
                        PhoneNumber = "0000000006",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "moaz.zakaria",
                        FirstName = "Moaz",
                        LastName = "Zakaria",
                        EmailAddress = "student7@university.com",
                        PhoneNumber = "0000000007",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "motaz.almasri",
                        FirstName = "Motaz",
                        LastName = "Al Masri",
                        EmailAddress = "student8@university.com",
                        PhoneNumber = "0000000008",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "nawar.altibi",
                        FirstName = "Nawar",
                        LastName = "Al Tibi",
                        EmailAddress = "student9@university.com",
                        PhoneNumber = "0000000009",
                        Role = "Student"
                    },
                    new Users
                    {
                        UserName = "ayman.durra",
                        FirstName = "Ayman",
                        LastName = "Durra",
                        EmailAddress = "student10@university.com",
                        PhoneNumber = "0000000010",
                        Role = "Student"
                    },

                    
                    new Users
                    {
                        UserName = "sami",
                        FirstName = "Sami",
                        LastName = "Teacher",
                        EmailAddress = "sami@university.com",
                        PhoneNumber = "0000000011",
                        Role = "Teacher"
                    },
                    new Users
                    {
                        UserName = "feryal",
                        FirstName = "Feryal",
                        LastName = "Teacher",
                        EmailAddress = "feryal@university.com",
                        PhoneNumber = "0000000012",
                        Role = "Teacher"
                    }
                };

                db.Users.AddRange(users);
                db.SaveChanges();

                Console.WriteLine("Students and teachers added successfully.");
            }
            else
            {
                Console.WriteLine("Users already exist. No data was added.");
            }

            if (!db.Courses.Any())
            {
                var sami = db.Users.Single(u => u.UserName == "sami");
                var feryal = db.Users.Single(u => u.UserName == "feryal");

                var Courses = new List<Courses>
    {
        new Courses
        {
            CourseName = "SQL",
            TeacherId = sami.UserId,
            StartDate = new DateTime(2026, 6, 1),
            EndDate = new DateTime(2026, 8, 30)
        },
        new Courses
        {
            CourseName = "C#",
            TeacherId = sami.UserId,
            StartDate = new DateTime(2026, 6, 1),
            EndDate = new DateTime(2026, 8, 30)
        },
        new Courses
        {
            CourseName = "Entity Framework",
            TeacherId = sami.UserId,
            StartDate = new DateTime(2026, 6, 1),
            EndDate = new DateTime(2026, 8, 30)
        },
        new Courses
        {
            CourseName = "Web API",
            TeacherId = feryal.UserId,
            StartDate = new DateTime(2026, 6, 1),
            EndDate = new DateTime(2026, 8, 30)
        },
        new Courses
        {
            CourseName = "React",
            TeacherId = feryal.UserId,
            StartDate = new DateTime(2026, 6, 1),
            EndDate = new DateTime(2026, 8, 30)
        }
    };

                db.Courses.AddRange(Courses);
                db.SaveChanges();

                Console.WriteLine("Courses added successfully.");
            }
            else
            {
                Console.WriteLine("Courses already exist.");
            }

            if (!db.Assignments.Any())
            {
                var courseNames = new[]
                {
        "SQL",
        "C#",
        "Entity Framework",
        "Web API",
        "React"
    };

                var random = new Random();

                foreach (var courseName in courseNames)
                {
                    var course = db.Courses.Single(c => c.CourseName == courseName);

                    for (int number = 1; number <= 5; number++)
                    {
                        var assignment = new Assignments
                        {
                            CourseId = course.CourseId,
                            AssignmentTitle = $"{course.CourseName} Assignment {number}",
                            Description = $"{course.CourseName} course assignment number {number}.",
                            Weight = 20m,
                            MaxGrade = 100,

                            
                            DueDate = DateTime.Today.AddDays(random.Next(-30, 31))
                        };

                        db.Assignments.Add(assignment);
                    }
                }

                db.SaveChanges();

                Console.WriteLine("Assignments added successfully.");
            }
            else
            {
                Console.WriteLine("Assignments already exist.");
            }

            if (!db.Syllabuses.Any())
            {
                var Courses = db.Courses.ToList();

                foreach (var course in Courses)
                {
                    var syllabus = new Syllabus
                    {
                        CourseId = course.CourseId,
                        Content = $"{course.CourseName} Course Plan: " +
                                  "Week 1: Introduction, " +
                                  "Week 2: Core Concepts, " +
                                  "Week 3: Practice, " +
                                  "Week 4: Project Work, " +
                                  "Week 5: Final Review."
                    };

                    db.Syllabuses.Add(syllabus);
                }

                db.SaveChanges();

                Console.WriteLine("Syllabuses added successfully.");
            }
            else
            {
                Console.WriteLine("Syllabuses already exist.");
            }

            if(!db.Comments.Any())
{
                var assignments = db.Assignments.ToList();

                var students = db.Users
                    .Where(u => u.Role == "Student")
                    .ToList();

                var commentTexts = new List<string>
    {
        "I have a question about this assignment.",
        "Can you explain the requirements again?",
        "The assignment was helpful.",
        "Could the due date be extended?",
        "I completed the first part of the assignment.",
        "I need help with this topic.",
        "Will we discuss this in class?",
        "The instructions are clear, thank you.",
        "Can you share an example solution?",
        "I will submit my work soon."
    };

                var random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    var randomAssignment = assignments[random.Next(assignments.Count)];
                    var randomStudent = students[random.Next(students.Count)];

                    var comment = new Comments
                    {
                        AssignmentId = randomAssignment.AssignmentId,
                        CreatedByUserId = randomStudent.UserId,
                        CreatedDate = DateTime.Now.AddDays(-random.Next(0, 15)),
                        CommentContent = commentTexts[i]
                    };

                    db.Comments.Add(comment);
                }

                db.SaveChanges();

                Console.WriteLine("Comments added successfully.");
            }
else
            {
                Console.WriteLine("Comments already exist.");
            }

            if (!db.Grades.Any())
            {
                var students = db.Users
                    .Where(u => u.Role == "Student")
                    .ToList();

                var assignments = db.Assignments.ToList();

                var random = new Random();

                var grades = new List<Grades>();

                foreach (var student in students)
                {
                    foreach (var assignment in assignments)
                    {
                        grades.Add(new Grades
                        {
                            StudentId = student.UserId,
                            AssignmentId = assignment.AssignmentId,

                           
                            Score = random.Next(50, 101)
                        });
                    }
                }

                db.Grades.AddRange(grades);
                db.SaveChanges();

                Console.WriteLine("Grades added successfully.");
            }
            else
            {
                Console.WriteLine("Grades already exist.");
            }




            var courses = db.Courses
    .OrderBy(c => c.CourseName)
    .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"Course: {course.CourseName}  TeacherId: {course.TeacherId}");
            }



          
//queries :


Console.WriteLine("\n--- All Courses ---");

            var allCourses = db.Courses.ToList();

            foreach (var course in allCourses)
            {
                Console.WriteLine($"Course: {course.CourseName}");
            }


            Console.WriteLine("\n--- Assignments for SQL Course ---");

            var sqlAssignments = db.Assignments
                .Where(a => a.Course.CourseName == "SQL")
                .ToList();

            foreach (var assignment in sqlAssignments)
            {
                Console.WriteLine(
                    $"Assignment Id: {assignment.AssignmentId} | Title: {assignment.AssignmentTitle}");
            }


            Console.WriteLine("\n--- All Students ---");

            var allStudents = db.Users
                .Where(u => u.Role == "Student")
                .ToList();

            foreach (var student in allStudents)
            {
                Console.WriteLine(
                    $"Student Id: {student.UserId} | Name: {student.FirstName} {student.LastName}");
            }

            Console.WriteLine("\n--- Comments for Assignment Id: 12---");

            int assignmentId = 12;

            var assignmentComments = db.Comments
                .Where(c => c.AssignmentId == assignmentId)
                .ToList();

            foreach (var comment in assignmentComments)
            {
                Console.WriteLine(
                    $"Comment Id: {comment.CommentId} | Comment: {comment.CommentContent}");
            }

            var studentGrades = db.Grades
                .Where(g => g.StudentId == 1)
                .ToList();

            Console.WriteLine("\n--- Assignments with Course and Teacher ---");

            var assignmentsWithDetails = db.Assignments
                .Include(a => a.Course)
                .ThenInclude(c => c.Teacher)
                .ToList();

            foreach (var assignment in assignmentsWithDetails)
            {
                Console.WriteLine(
                    $"Assignment Id: {assignment.AssignmentId} | " +
                    $"Title: {assignment.AssignmentTitle} | " +
                    $"Course: {assignment.Course.CourseName} | " +
                    $"Teacher: {assignment.Course.Teacher.FirstName} {assignment.Course.Teacher.LastName}");
            }

            Console.WriteLine("\n--- Average Grade Per Course ---");

            var averageGradesPerCourse = db.Grades
                .GroupBy(g => new
                {
                    g.Assignment.CourseId,
                    g.Assignment.Course.CourseName
                })
                .Select(group => new
                {
                    CourseId = group.Key.CourseId,
                    CourseName = group.Key.CourseName,
                    AverageGrade = group.Average(g => g.Score)
                })
                .OrderBy(result => result.CourseName)
                .ToList();

            foreach (var course in averageGradesPerCourse)
            {
                Console.WriteLine(
                    $"Course Id: {course.CourseId} | " +
                    $"Course: {course.CourseName} | " +
                    $"Average Grade: {course.AverageGrade:F2}");
            }

            string GetLetterGrade(decimal score)
            {
                if (score < 0 || score > 100)
                {
                    return "Invalid Score";
                }

                if (score >= 90)
                {
                    return "A";
                }

                if (score >= 80)
                {
                    return "B";
                }

                if (score >= 70)
                {
                    return "C";
                }

                if (score >= 60)
                {
                    return "D";
                }

                return "F";
            }

            decimal GetGpaPoint(string letterGrade)
            {
                return letterGrade switch
                {
                    "A" => 4.0m,
                    "B" => 3.0m,
                    "C" => 2.0m,
                    "D" => 1.0m,
                    _ => 0.0m
                };
            }

            decimal CalculateGpa(int studentId)
            {
                var studentGrades = db.Grades
                    .Where(g => g.StudentId == studentId)
                    .Include(g => g.Assignment)
                    .ThenInclude(a => a.Course)
                    .ToList();

                if (!studentGrades.Any())
                {
                    return 0m;
                }

                var courseGpaPoints = studentGrades
                    .GroupBy(g => g.Assignment.CourseId)
                    .Select(group =>
                    {
                        decimal totalWeight = group.Sum(g => (decimal)g.Assignment.Weight);

                        decimal courseScore =
                            group.Sum(g => g.Score * (decimal)g.Assignment.Weight)
                            / totalWeight;

                        string letterGrade = GetLetterGrade(courseScore);

                        return GetGpaPoint(letterGrade);
                    })
                    .ToList();

                return courseGpaPoints.Average();
            }

            Console.WriteLine("\n--- GPA for Student Id: 1 ---");

            decimal gpa = CalculateGpa(1);

            Console.WriteLine($"Student Id: 1 | GPA: {gpa:F2} / 4.00");

            var studentToUpdate = db.Users
                .FirstOrDefault(u => u.EmailAddress == "student1@gmail.com");

            if (studentToUpdate != null)
            {
                studentToUpdate.Role = "Teacher";

                db.SaveChanges();

                Console.WriteLine(
                    $"{studentToUpdate.FirstName} {studentToUpdate.LastName}'s role was updated to Teacher.");
            }
            else
            {
                Console.WriteLine("Student was not found.");
            }

            int commentIdToDelete = 10;

            var commentToDelete = db.Comments.Find(commentIdToDelete);

            if (commentToDelete != null)
            {
                db.Comments.Remove(commentToDelete);

                db.SaveChanges();

                Console.WriteLine($"Comment Id {commentIdToDelete} was deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Comment Id {commentIdToDelete} was not found.");
            }


        }
    }
}
