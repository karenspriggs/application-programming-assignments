using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserProfileApp2.Models
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string EstimatedBirthYear { get; set; }
        public string MovieQuote { get; set; }
    }
}