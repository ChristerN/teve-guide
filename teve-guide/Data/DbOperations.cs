using teve_guide.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teve_guide.Data
{
    public class DbOperations
    {
        private TeveGuideEntities db = new TeveGuideEntities();

        public bool CheckUserCredentials(string username, string password)
        {
            var user = db.users
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password));
            if (user.Any())
            { return true; }

            else
            { return false; }
        }

    }
}