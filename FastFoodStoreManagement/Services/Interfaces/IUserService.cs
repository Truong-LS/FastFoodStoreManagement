using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();
        Users? GetUserById(int id);
        Users? GetUserByUsername(string username);
        Users? Login(string username, string password);
    }
}
