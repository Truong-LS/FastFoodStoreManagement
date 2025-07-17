using Models;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<Users> GetAllUsers();
        Users? GetUserById(int id);
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
} 