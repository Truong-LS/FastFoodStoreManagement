using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ShiftDAO _shiftDAO;

        public ShiftRepository()
        {
            _shiftDAO = new ShiftDAO();
        }

        public async Task<List<Shifts>> GetAllShifts()
        {
            return await _shiftDAO.GetAllShifts();
        }

        public async Task<Shifts?> GetShiftById(int id)
        {
            return await _shiftDAO.GetShiftById(id);
        }

        public async Task AddShift(Shifts shift)
        {
            await _shiftDAO.AddShift(shift);
        }

        public async Task UpdateShift(Shifts shift)
        {
            await _shiftDAO.UpdateShift(shift);
        }

        public async Task DeleteShift(int id)
        {
            await _shiftDAO.DeleteShift(id);
        }
    }
} 