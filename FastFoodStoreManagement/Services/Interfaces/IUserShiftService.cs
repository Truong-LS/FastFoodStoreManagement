using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserShiftService
    {
        List<UserShifts> GetAllUserShifts();
        List<UserShifts> SearchUserShiftsByDate(int? day, int? month, int? year);
        UserShifts? GetUserShiftById(int id);
        void AddUserShift(UserShifts userShift);
        void UpdateUserShift(UserShifts userShift);
        void DeleteUserShift(int id);
    }
}