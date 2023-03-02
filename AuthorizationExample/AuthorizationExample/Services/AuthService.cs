using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationExample.Services
{
    public class AuthService
    {
        public bool IsPageAuthorized(string pageName, User currentUser)
        {
            if (currentUser == null)
            {
                return false;
            }

            string rawAuthRole = currentUser.Role;
            string currentAuthRole = rawAuthRole.Replace(@" ", string.Empty);

            if (pageName == "List")
            {
                if (currentAuthRole == "User" || currentAuthRole == "Admin" || currentAuthRole == "SuperAdmin")
                {
                    return true;
                }
            }

            if (pageName == "Create")
            {
                if (currentAuthRole == "Admin" || currentAuthRole == "SuperAdmin")
                {
                    return true;
                }
            }

            if (pageName == "Edit")
            {
                if (currentAuthRole == "Admin" || currentAuthRole == "SuperAdmin")
                {
                    return true;
                }
            }

            if (pageName == "Delete")
            {
                if (currentAuthRole == "SuperAdmin")
                {
                    return true;
                }
            }

            return false;
        }
    }
}