using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository()
        {
            _userDAO = new UserDAO();
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _userDAO.GetAllUsers();
        }

        public async Task<Users?> GetUserById(int id)
        {
            return await _userDAO.GetUserById(id);
        }

        public async Task AddUser(Users user)
        {
            await _userDAO.AddUser(user);
        }

        public async Task UpdateUser(Users user)
        {
            await _userDAO.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userDAO.DeleteUser(id);
        }
    }
} 