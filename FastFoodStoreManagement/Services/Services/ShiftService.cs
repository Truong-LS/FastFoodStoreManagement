using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService()
        {
            _shiftRepository = new Repositories.Repositories.ShiftRepository();
        }

        public List<Shifts> GetAllShifts()
        {
            return _shiftRepository.GetAllShifts();
        }

        public Shifts? GetShiftById(int id)
        {
            return _shiftRepository.GetShiftById(id);
        }

        public void AddShift(Shifts shift)
        {
            _shiftRepository.AddShift(shift);
        }

        public void UpdateShift(Shifts shift)
        {
            _shiftRepository.UpdateShift(shift);
        }

        public void DeleteShift(int id)
        {
            _shiftRepository.DeleteShift(id);
        }
    }
}