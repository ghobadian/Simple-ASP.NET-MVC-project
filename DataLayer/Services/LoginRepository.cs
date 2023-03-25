using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MyCmsContext db;
        public LoginRepository(MyCmsContext db) {
            this.db = db;
        }

        public bool DoesUserExists(string username, string password)
        {
            return db.AdminLogins.Any(adminLogin => adminLogin.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && adminLogin.Password == password);
        }
    }
}
