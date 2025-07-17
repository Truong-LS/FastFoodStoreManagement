using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IShiftRepository
    {
        Task<List<Shifts>> GetAllShifts();
        Task<Shifts?> GetShiftById(int id);
        Task AddShift(Shifts shift);
        Task UpdateShift(Shifts shift);
        Task DeleteShift(int id);
    }
} 