using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teve_guide.Data;
using System.Web.Mvc;

namespace teve_guide.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRole;
        private DbOperations db = new DbOperations();
        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRole = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var roles in userAssignedRole)
            {
                //authorize = db.IsUserInRole(httpContext.User.Identity.Name, roles);
                if (authorize)
                    return authorize;
            }
            return authorize;
        }
    }
}