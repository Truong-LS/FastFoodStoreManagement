using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserShiftRepository : IUserShiftRepository
    {
        private readonly UserShiftDAO _userShiftDAO;

        public UserShiftRepository()
        {
            _userShiftDAO = new UserShiftDAO();
        }

        public async Task<List<UserShifts>> GetAllUserShifts()
        {
            return await _userShiftDAO.GetAllUserShifts();
        }

        public async Task<List<UserShifts>> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            return await _userShiftDAO.SearchUserShiftsByDate(day, month, year);
        }

        public async Task<UserShifts?> GetUserShiftById(int id)
        {
            return await _userShiftDAO.GetUserShiftById(id);
        }

        public async Task AddUserShift(UserShifts userShift)
        {
            await _userShiftDAO.AddUserShift(userShift);
        }

        public async Task UpdateUserShift(UserShifts userShift)
        {
            await _userShiftDAO.UpdateUserShift(userShift);
        }

        public async Task DeleteUserShift(int id)
        {
            await _userShiftDAO.DeleteUserShift(id);
        }
    }
} 