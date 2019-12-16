using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository
    {
        public ExaminationContext examinationContext = new ExaminationContext();

        public User GetUserByToken(string token)
        {
            return examinationContext.User.Where(u => u.Token == token).FirstOrDefault();
        }
        public bool Add(User user, int deptId)
        {
            try
            {
                if (user.Type == 1)
                {
                    var student = new Entities.Student { Name = user.UserName, Dept_id = deptId, User = user };
                    examinationContext.Student.Add(student);
                    examinationContext.SaveChanges();

                    var crsList = new List<Entities.StudentCourse>();
                    examinationContext.Course.Select(c =>new { c.Id }).ToList().ForEach(l => crsList.Add( new Entities.StudentCourse { Course_Id = l.Id, Student_Id = user.Id }));
                    examinationContext.StudentCourse.AddRange(crsList);
                }
                else if (user.Type == 2)
                {
                    var instructor = new Entities.Instructor { Name = user.UserName, Dept_Id = deptId, User = user };
                    examinationContext.Instructor.Add(instructor);
                    examinationContext.SaveChanges();

                    var crsList = new List<Entities.InstructorCourse>();
                    examinationContext.Course.Select(c => new { c.Id }).ToList().ForEach(l => crsList.Add(new Entities.InstructorCourse { Course_Id = l.Id, Instructor_Id = user.Id }));
                    examinationContext.InstructorCourse.AddRange(crsList);
                }
                examinationContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User Login(string email, string pass)
        {
            try
            {
                var user = examinationContext.User.Where(u => u.Email == email && u.Password == pass)
                    .FirstOrDefault();
                if (user != null)
                {
                    user.Token = Guid.NewGuid().ToString();
                    examinationContext.User.AddOrUpdate(user);
                    examinationContext.SaveChanges();
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
