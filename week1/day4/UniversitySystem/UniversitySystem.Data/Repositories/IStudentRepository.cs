using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data.Entities;

namespace UniversitySystem.Data.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        Student? GetById(int id);

        void Add(Student student);

        void Update(Student student);

        void Delete(Student student);
    }
}
