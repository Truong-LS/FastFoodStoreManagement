using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<Users>> GetAllUsers()
        {
            _userRepos.Add(user);
            return await _userRepository.GetAllUsers();
        }

        public void DeleteUser(int id)
        public async Task<Users?> GetUserById(int id)
        {
            _userRepos.Delete(id);
            return await _userRepository.GetUserById(id);
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
        public async Task AddUser(Users user)
        {
            return _userRepos.GetByUsername(username);
            await _userRepository.AddUser(user);
        }

        public Users? Login(string username, string password)
        public async Task UpdateUser(Users user)
        {
            return _userRepos.GetByUsernameAndPassword(username, password);
        }

        public void UpdateUser(Users user)
        public async Task DeleteUser(int id)
        {
            _userRepos.Update(user);
            await _userRepository.DeleteUser(id);
        }
    }
}
