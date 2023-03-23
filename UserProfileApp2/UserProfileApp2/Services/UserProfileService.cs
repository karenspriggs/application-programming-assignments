using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserProfileApp2.Models;
using UserProfileApp2.Services;

namespace UserProfileApp2
{
    public class UserProfileService
    {
        static List<UserProfile> userProfiles = new List<UserProfile>();

        public int GetCurrentID()
        {
            return userProfiles.Count;
        }

        public void AddUserProfile(UserProfile profileToAdd)
        {
            profileToAdd.ID = userProfiles.Count + 1;

            int userAge = profileToAdd.Age;

            // System.DateTime.Now.Year is returning the year 2024, hence the -1
            int yearIfHadBDay = System.DateTime.Now.Year - 1 - userAge;
            int yearIfNoBDay = yearIfHadBDay++;

            profileToAdd.EstimatedBirthYear = $"If you had your birthday this year, I think you were born in {yearIfHadBDay}, otherwise you were born in {yearIfNoBDay}"; 
            profileToAdd.MovieQuote = MovieQuoteService.GetRandomQuote();

            userProfiles.Add(profileToAdd);
        }

        public UserProfile GetUserProfileWithID(int ID)
        {
            return userProfiles.Where(user => user.ID == ID).FirstOrDefault();
        }
    }
}