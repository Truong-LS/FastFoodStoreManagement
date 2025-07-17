using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users?> GetUserById(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(int id);
        IEnumerable<Users> GetAllUsers();
        Users? GetUserById(int id);
        Users? GetUserByUsername(string username);
        Users? Login(string username, string password);
        void CreateUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
