using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public class UserShiftRepository : IUserShiftRepository
    {
        private readonly UserShiftDAO _userShiftDAO;

        public UserShiftRepository()
        {
            _userShiftDAO = new UserShiftDAO();
        }

        public List<UserShifts> GetAllUserShifts()
        {
            return _userShiftDAO.GetAllUserShifts();
        }

        public List<UserShifts> SearchUserShiftsByDate(int? day, int? month, int? year)
        {
            return _userShiftDAO.SearchUserShiftsByDate(day, month, year);
        }

        public UserShifts? GetUserShiftById(int id)
        {
            return _userShiftDAO.GetUserShiftById(id);
        }

        public void AddUserShift(UserShifts userShift)
        {
            _userShiftDAO.AddUserShift(userShift);
        }

        public void UpdateUserShift(UserShifts userShift)
        {
            _userShiftDAO.UpdateUserShift(userShift);
        }

        public void DeleteUserShift(int id)
        {
            _userShiftDAO.DeleteUserShift(id);
        }
    }
} 