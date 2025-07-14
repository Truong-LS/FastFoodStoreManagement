using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepos _userRepos;

        public UserService(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }

        public void CreateUser(Users user)
        {
            _userRepos.Add(user);
        }

        public void DeleteUser(int id)
        {
            _userRepos.Delete(id);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _userRepos.GetAll();
        }

        public Users? GetUserById(int id)
        {
            return _userRepos.GetById(id);
        }

        public Users? GetUserByUsername(string username)
        {
            return _userRepos.GetByUsername(username);
        }

        public Users? Login(string username, string password)
        {
            return _userRepos.GetByUsernameAndPassword(username, password);
        }

        public void UpdateUser(Users user)
        {
            _userRepos.Update(user);
        }
    }
}
