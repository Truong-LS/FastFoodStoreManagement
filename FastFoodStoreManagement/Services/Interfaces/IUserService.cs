using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
    }
} 