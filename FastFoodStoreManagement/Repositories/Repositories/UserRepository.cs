using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository()
        {
            _userDAO = new UserDAO();
        }

        public List<Users> GetAllUsers()
        {
            return _userDAO.GetAllUsers();
        }

        public Users? GetUserById(int id)
        {
            return _userDAO.GetUserById(id);
        }

        public void AddUser(Users user)
        {
            _userDAO.AddUser(user);
        }

        public void UpdateUser(Users user)
        {
            _userDAO.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userDAO.DeleteUser(id);
        }
    }
}