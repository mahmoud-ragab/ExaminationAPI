using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class InstructorRepository
    {
        public ExaminationContext context = new ExaminationContext();
        public Instructor getInstructorInformation(int id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var instructor = context.Database.SqlQuery<Instructor>("getInstructorByID @ins_ID", _Ins_id).SingleOrDefault();
            return instructor;
        }
        public Instructor getInstructorCourses(int id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var courses = context.Database.SqlQuery<List<Course>>("getInstructorListOfCourses @ins_ID", _Ins_id).SingleOrDefault();
            return courses;
        }
        public Instructor getInstructorExamList(int id,int c_id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var _c_id = new SqlParameter("@c_ID", c_id);
            var instructor = context.Database.SqlQuery<List<Exam>>("getInstructorByID @ins_ID @c_ID", _Ins_id,_c_id).SingleOrDefault();
            return instructor;
        }
        public Instructor getInstructorInformation(int id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var instructor = context.Database.SqlQuery<Instructor>("getInstructorByID @ins_ID", _Ins_id).SingleOrDefault();
            return instructor;
        }

    }
}
