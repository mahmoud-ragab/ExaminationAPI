using System;
using System.Collections.Generic;
using Data.Entities;
using Data.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class InstructorService
    {
        public static InstructorRepository instructorRepository = new InstructorRepository();
        public static Instructor GetInstructor(int id)
        {
            return instructorRepository.getInstructorInformation(id);
        }
        public static List<Course> GetInstructorCoursesList(int id)
        {
            return instructorRepository.GetInstructorCoursesList(id);
        }


    }
}
