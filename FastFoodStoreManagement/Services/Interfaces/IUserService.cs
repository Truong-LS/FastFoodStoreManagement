using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        Users? GetUserById(int id);
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}