﻿using teve_guide.Models.db;
using System.Linq;
using System.Data.Entity;

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

        public bool IsUserInRole(string userName, string roleName)
        {
            var role = db.users
                 .Where(x => x.Username.Equals(userName))
                 .Include(x => x.Role).Where(x => x.Role.Equals(roleName));

            return role.Any();
        }

    }
}