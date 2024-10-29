using RSM.BOL.Models;
using RSM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.DAL.DatabaseService
{
    public class UserDb
    {
        private readonly RSMContext _ctx;
        public UserDb()
        {
            _ctx = new RSMContext();
        }
        public bool AuthenticateUser(string email, string password)
        {
            var data = _ctx.Users.Where(u => u.UserEmail == email
              && u.UserPassword == password).FirstOrDefault();
            return data != null;
        }
    }
}
