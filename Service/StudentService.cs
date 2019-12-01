using Data.EF;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService
    {
        public StudentRepository studentRepository = new StudentRepository();

        public List<Student> GetAll()
        {
            return studentRepository.GetAll();
        }
    }
}
