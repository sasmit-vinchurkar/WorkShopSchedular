using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class UserBusiness
    {
        public List<UserBO> GetTrainers()
        {
            UserDB userDB = new UserDB();
            List<UserBO> userBOs =  userDB.GetTrainers();
            return userBOs;
        }

    }
}
