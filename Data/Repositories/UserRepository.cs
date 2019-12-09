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
        public bool Add(User user)
        {
            try
            {
                examinationContext.User.AddOrUpdate(user);
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
