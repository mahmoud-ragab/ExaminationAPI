using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentRepository
    {
        public ExaminationContext examinationContext;
        public StudentRepository()
        {
            examinationContext = new ExaminationContext();
        }
        public List<Student> GetAll()
        {
            return examinationContext.Student.ToList();
        }
    }
}
