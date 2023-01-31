using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserProfileApp.Models
{
    /// <summary>
    /// Model that stores four properties of a user:
    /// First Name: their first name
    /// Last Name: their last name
    /// Age: their age
    /// Occupation: their occupation
    /// </summary>
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
    }
}