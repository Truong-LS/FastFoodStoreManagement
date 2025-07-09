using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories.Interfaces
{
    public interface IUserRepos
    {
        IEnumerable<Users> GetAll();
        Users? GetById(int id);
        Users? GetByUsername(string username);
        Users? GetByUsernameAndPassword(string username, string password);
    }
}
