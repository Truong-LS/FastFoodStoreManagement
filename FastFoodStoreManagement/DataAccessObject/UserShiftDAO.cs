using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessObject
{
    public class UserShiftDAO
    {
        private readonly FastFoodDbContext _context;

        public UserShiftDAO()
        {
            _context = new FastFoodDbContext();
        }

        public List<UserShifts> GetAllUserShifts()
        {
            return _context.UserShifts.Include(us => us.Shift).Include(us => us.User).ToList();
        }

        public List<UserShifts> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            var query = _context.UserShifts.Include(us => us.Shift).Include(us => us.User).AsQueryable();

            if (day.HasValue && day.Value > 0)
            {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Day == day.Value);
            }
            if (month.HasValue && month.Value > 0)
            {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Month == month.Value);
            }
            if (year.HasValue && year.Value > 0)
            {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Year == year.Value);
            }

            return query.ToList();
        }

        public UserShifts? GetUserShiftById(int id)
        {
            return _context.UserShifts.Include(us => us.Shift).Include(us => us.User).FirstOrDefault(us => us.UserShiftId == id);
        }

        public void AddUserShift(UserShifts userShift)
        {
            // Get the maximum UserShiftId and increment it for the new user shift
            var maxUserShiftId = _context.UserShifts.Any() ? _context.UserShifts.Max(us => us.UserShiftId) : 0;
            userShift.UserShiftId = maxUserShiftId + 1;

            _context.UserShifts.Add(userShift);
            _context.SaveChanges();
        }

        public void UpdateUserShift(UserShifts userShift)
        {
            _context.UserShifts.Update(userShift);
            _context.SaveChanges();
        }

        public void DeleteUserShift(int id)
        {
            var userShift = _context.UserShifts.FirstOrDefault(us => us.UserShiftId == id);
            if (userShift != null)
            {
                _context.UserShifts.Remove(userShift);
                _context.SaveChanges();
            }
        }
    }
} 