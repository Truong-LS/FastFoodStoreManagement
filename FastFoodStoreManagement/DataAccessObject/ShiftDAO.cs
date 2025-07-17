using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ShiftDAO
    {
        private readonly FastFoodDbContext _context;

        public ShiftDAO()
        {
            _context = new FastFoodDbContext();
        }

        public async Task<List<Shifts>> GetAllShifts()
        {
            return await _context.Shifts.ToListAsync();
        }

        public async Task<Shifts?> GetShiftById(int id)
        {
            return await _context.Shifts.FindAsync(id);
        }

        public async Task AddShift(Shifts shift)
        {
            // Get the maximum ShiftId and increment it for the new shift
            var maxShiftId = await _context.Shifts.AnyAsync() ? await _context.Shifts.MaxAsync(s => s.ShiftId) : 0;
            shift.ShiftId = maxShiftId + 1;

            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShift(Shifts shift)
        {
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShift(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift != null)
            {
                _context.Shifts.Remove(shift);
                await _context.SaveChangesAsync();
            }
        }
    }
} 