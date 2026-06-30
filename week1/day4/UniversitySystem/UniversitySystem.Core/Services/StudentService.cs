using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.DTOs;
using UniversitySystem.Core.Forms;
using UniversitySystem.Data.Entities;
using UniversitySystem.Data.Repositories;

namespace UniversitySystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentDto> GetAll()
        {
            var students = _studentRepository.GetAll();

            return students.Select(student => new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            }).ToList();
        }

        public StudentDto? GetById(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public StudentDto Create(CreateStudentForm form)
        {
            var student = new Student
            {
                Name = form.Name,
                Email = form.Email
            };

            _studentRepository.Add(student);

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };
        }

        public bool Update(int id, UpdateStudentForm form)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                return false;
            }

            student.Name = form.Name;
            student.Email = form.Email;

            _studentRepository.Update(student);

            return true;
        }

        public bool Delete(int id)
        {
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                return false;
            }

            _studentRepository.Delete(student);

            return true;
        }
    }
}
