using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
    }
} 