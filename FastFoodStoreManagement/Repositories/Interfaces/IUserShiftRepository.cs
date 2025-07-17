using Models;
using System.Collections.Generic;

namespace Repositories.Interfaces
{
    public interface IUserShiftRepository
    {
        List<UserShifts> GetAllUserShifts();
        List<UserShifts> SearchUserShiftsByDate(int? day, int? month, int? year);
        UserShifts? GetUserShiftById(int id);
        void AddUserShift(UserShifts userShift);
        void UpdateUserShift(UserShifts userShift);
        void DeleteUserShift(int id);
    }
}