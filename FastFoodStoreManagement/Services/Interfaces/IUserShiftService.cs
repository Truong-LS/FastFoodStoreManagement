using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserShiftService
    {
        Task<List<UserShifts>> GetAllUserShifts();
        Task<List<UserShifts>> SearchUserShiftsByDate(int? day, int? month, int? year);
        Task<UserShifts?> GetUserShiftById(int id);
        Task AddUserShift(UserShifts userShift);
        Task UpdateUserShift(UserShifts userShift);
        Task DeleteUserShift(int id);
    }
} 