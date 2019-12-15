using Data;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        public UserRepository userRepository = new UserRepository();

        public int GetUserIdByToken(string token)
        {
            return userRepository.GetUserByToken(token).Id;
        }

        public User Register(string userName, string email, string pass, int type, int deptId)
        {
            var user = new User
            {
                UserName = userName.ToLower(),
                Email = email.ToLower(),
                Password = pass,
                Type = type,
                Token = Guid.NewGuid().ToString(),
            };
            return userRepository.Add(user, deptId) ? user : null;
        }

        public User Login(string email, string password)
        {
            var user = userRepository.Login(email.ToLower(), password);
            return user != null ? user : null;
        }
    }
}
