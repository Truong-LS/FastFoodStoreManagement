using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserShiftService : IUserShiftService
    {
        private readonly IUserShiftRepository _userShiftRepository;

        public UserShiftService()
        {
            _userShiftRepository = new Repositories.Repositories.UserShiftRepository();
        }

        public async Task<List<UserShifts>> GetAllUserShifts()
        {
            return await _userShiftRepository.GetAllUserShifts();
        }

        public async Task<List<UserShifts>> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            return await _userShiftRepository.SearchUserShiftsByDate(day, month, year);
        }

        public async Task<UserShifts?> GetUserShiftById(int id)
        {
            return await _userShiftRepository.GetUserShiftById(id);
        }

        public async Task AddUserShift(UserShifts userShift)
        {
            await _userShiftRepository.AddUserShift(userShift);
        }

        public async Task UpdateUserShift(UserShifts userShift)
        {
            await _userShiftRepository.UpdateUserShift(userShift);
        }

        public async Task DeleteUserShift(int id)
        {
            await _userShiftRepository.DeleteUserShift(id);
        }
    }
} 