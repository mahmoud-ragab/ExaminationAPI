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
        public List<Course> GetInstructorCoursesList(int id)
        {
            List<Course> courses = context.Database.SqlQuery<Course>("getInstructorListOfCourses @ins_ID", new SqlParameter("@ins_ID", id)).ToList();
            return courses;
        }
        public List<Exam> GetInstructorExamListByCourse(int id, int c_id)
        {
            var _Ins_id = new SqlParameter("@ins_ID", id);
            var _c_id = new SqlParameter("@c_ID", c_id);
            var exams = context.Database.SqlQuery<Exam>("getInstructorExamListByCourse @ins_ID @c_ID", _Ins_id, _c_id).ToList();
            return exams;
        }
        public List<AnswerSheet> GetExamAnswerSheetList(int e_id)
        {
            var _id = new SqlParameter("@exam_ID", e_id);
            var answerSheets = context.Database.SqlQuery<AnswerSheet>("getInstructorAnswerSheetOfExam @exam_ID",_id).ToList();
            return answerSheets;
        }

    }
}
