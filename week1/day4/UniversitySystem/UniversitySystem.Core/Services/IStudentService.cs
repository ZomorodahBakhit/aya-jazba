using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Core.DTOs;
using UniversitySystem.Core.Forms;

namespace UniversitySystem.Core.Services
{
    public interface IStudentService
    {
        List<StudentDto> GetAll();

        StudentDto? GetById(int id);

        StudentDto Create(CreateStudentForm form);

        bool Update(int id, UpdateStudentForm form);

        bool Delete(int id);
    }
}
