using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class UserDAO
    {
        private readonly FastFoodDbContext _context;

        public UserDAO()
        {
            _context = new FastFoodDbContext();
        }

        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Users? GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}