using DataAccessObject;
using Models;
using Repositories.Interfaces;
using System.Collections.Generic;

namespace Repositories.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ShiftDAO _shiftDAO;

        public ShiftRepository()
        {
            _shiftDAO = new ShiftDAO();
        }

        public List<Shifts> GetAllShifts()
        {
            return _shiftDAO.GetAllShifts();
        }

        public Shifts? GetShiftById(int id)
        {
            return _shiftDAO.GetShiftById(id);
        }

        public void AddShift(Shifts shift)
        {
            _shiftDAO.AddShift(shift);
        }

        public void UpdateShift(Shifts shift)
        {
            _shiftDAO.UpdateShift(shift);
        }

        public void DeleteShift(int id)
        {
            _shiftDAO.DeleteShift(id);
        }
    }
}