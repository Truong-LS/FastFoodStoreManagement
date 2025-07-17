using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<UserShifts>> GetAllUserShifts()
        {
            return await _context.UserShifts.Include(us => us.Shift).Include(us => us.User).ToListAsync();
        }

        public async Task<List<UserShifts>> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            var query = _context.UserShifts.Include(us => us.Shift).Include(us => us.User).AsQueryable();

            if (day.HasValue && day.Value > 0) {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Day == day.Value);
            }
            if (month.HasValue && month.Value > 0) {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Month == month.Value);
            }
            if (year.HasValue && year.Value > 0) {
                query = query.Where(us => us.WorkDate.HasValue && us.WorkDate.Value.Year == year.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<UserShifts?> GetUserShiftById(int id)
        {
            return await _context.UserShifts.Include(us => us.Shift).Include(us => us.User).FirstOrDefaultAsync(us => us.UserShiftId == id);
        }

        public async Task AddUserShift(UserShifts userShift)
        {
            // Get the maximum UserShiftId and increment it for the new user shift
            var maxUserShiftId = await _context.UserShifts.AnyAsync() ? await _context.UserShifts.MaxAsync(us => us.UserShiftId) : 0;
            userShift.UserShiftId = maxUserShiftId + 1;

            _context.UserShifts.Add(userShift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserShift(UserShifts userShift)
        {
            _context.UserShifts.Update(userShift);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserShift(int id)
        {
            var userShift = await _context.UserShifts.FirstOrDefaultAsync(us => us.UserShiftId == id);
            if (userShift != null)
            {
                _context.UserShifts.Remove(userShift);
                await _context.SaveChangesAsync();
            }
        }
    }
} 