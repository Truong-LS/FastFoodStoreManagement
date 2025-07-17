using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService()
        {
            _shiftRepository = new Repositories.Repositories.ShiftRepository();
        }

        public async Task<List<Shifts>> GetAllShifts()
        {
            return await _shiftRepository.GetAllShifts();
        }

        public async Task<Shifts?> GetShiftById(int id)
        {
            return await _shiftRepository.GetShiftById(id);
        }

        public async Task AddShift(Shifts shift)
        {
            await _shiftRepository.AddShift(shift);
        }

        public async Task UpdateShift(Shifts shift)
        {
            await _shiftRepository.UpdateShift(shift);
        }

        public async Task DeleteShift(int id)
        {
            await _shiftRepository.DeleteShift(id);
        }
    }
} 