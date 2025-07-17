using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessObject
{
    public class ShiftDAO
    {
        private readonly FastFoodDbContext _context;

        public ShiftDAO()
        {
            _context = new FastFoodDbContext();
        }

        public List<Shifts> GetAllShifts()
        {
            return _context.Shifts.ToList();
        }

        public Shifts? GetShiftById(int id)
        {
            return _context.Shifts.Find(id);
        }

        public void AddShift(Shifts shift)
        {
            // Get the maximum ShiftId and increment it for the new shift
            var maxShiftId = _context.Shifts.Any() ? _context.Shifts.Max(s => s.ShiftId) : 0;
            shift.ShiftId = maxShiftId + 1;

            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void UpdateShift(Shifts shift)
        {
            _context.Shifts.Update(shift);
            _context.SaveChanges();
        }

        public void DeleteShift(int id)
        {
            var shift = _context.Shifts.Find(id);
            if (shift != null)
            {
                _context.Shifts.Remove(shift);
                _context.SaveChanges();
            }
        }
    }
} 