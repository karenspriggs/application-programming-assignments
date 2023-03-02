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

            string currentAuthRole = currentUser.Role;

            if (pageName == "List")
            {
                if (currentAuthRole == "User" || currentAuthRole == "Admin" || currentAuthRole == "Super Admin")
                {
                    return true;
                }
            }

            if (pageName == "Create")
            {
                if (currentAuthRole == "Admi" || currentAuthRole == "Super Admin")
                {
                    return true;
                }
            }

            if (pageName == "Edit")
            {
                if (currentAuthRole == "Admin" || currentAuthRole == "Super Admin")
                {
                    return true;
                }
            }

            if (pageName == "Delete")
            {
                if (currentAuthRole == "Super Admin")
                {
                    return true;
                }
            }

            return false;
        }
    }
}