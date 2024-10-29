using RSM.DAL.Context;
using RSM.DAL.DatabaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSM.BLL
{
    public class UserBll
    {
        private readonly UserDb userDb;
        public UserBll() 
        {
            userDb = new UserDb();
        }
        public bool AuthenticateUser(string email, string password)
        {
           
            return userDb.AuthenticateUser(email, password);
        }
    }
}
