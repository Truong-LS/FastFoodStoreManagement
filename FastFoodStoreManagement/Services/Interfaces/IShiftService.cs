using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IShiftService
    {
        List<Shifts> GetAllShifts();
        Shifts? GetShiftById(int id);
        void AddShift(Shifts shift);
        void UpdateShift(Shifts shift);
        void DeleteShift(int id);
    }
}