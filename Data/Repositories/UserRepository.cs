﻿using System;
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
                }
                else if (user.Type == 2)
                {
                    var instructor = new Entities.Instructor { Name = user.UserName, Dept_Id = deptId, User = user };
                    examinationContext.Instructor.Add(instructor);
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
