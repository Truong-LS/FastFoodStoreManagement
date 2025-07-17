using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class UserRepos : IUserRepos
    {
        private readonly FastFoodDbContext _context;

        public UserRepos(FastFoodDbContext context)
        {
            _context = context;
        }

        public void Add(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public Users? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
        }

        public Users? GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.UserName.ToLower() == username.ToLower() && u.Password == password);
        }

        public void Update(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
