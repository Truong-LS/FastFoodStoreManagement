using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Services
{
    public static class SessionService
    {
        private static Users? _currentUser;

        public static void SetUser(Users user) => _currentUser = user;

        public static Users? GetUser() => _currentUser;

        public static void ClearUser() => _currentUser = null;
    }
}
