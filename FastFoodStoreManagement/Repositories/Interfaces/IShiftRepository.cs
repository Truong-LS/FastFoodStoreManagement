using Models;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IShiftRepository
    {
        List<Shifts> GetAllShifts();
        Shifts? GetShiftById(int id);
        void AddShift(Shifts shift);
        void UpdateShift(Shifts shift);
        void DeleteShift(int id);
    }
}