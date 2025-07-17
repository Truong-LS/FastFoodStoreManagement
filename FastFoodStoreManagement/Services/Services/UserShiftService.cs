using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class UserShiftService : IUserShiftService
    {
        private readonly IUserShiftRepository _userShiftRepository;

        public UserShiftService()
        {
            _userShiftRepository = new Repositories.Repositories.UserShiftRepository();
        }

        public List<UserShifts> GetAllUserShifts()
        {
            return _userShiftRepository.GetAllUserShifts();
        }

        public List<UserShifts> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            return _userShiftRepository.SearchUserShiftsByDate(day, month, year);
        }

        public UserShifts? GetUserShiftById(int id)
        {
            return _userShiftRepository.GetUserShiftById(id);
        }

        public void AddUserShift(UserShifts userShift)
        {
            _userShiftRepository.AddUserShift(userShift);
        }

        public void UpdateUserShift(UserShifts userShift)
        {
            _userShiftRepository.UpdateUserShift(userShift);
        }

        public void DeleteUserShift(int id)
        {
            _userShiftRepository.DeleteUserShift(id);
        }
    }
}