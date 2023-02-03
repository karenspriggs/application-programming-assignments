using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserProfileApp.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }

        // This action is executed when the user clicks the submit button
        // If they fill out the form again and hit submit, the old values are replaced with the new ones
        // POST: UserProfile/Create
        [HttpPost]
        public ActionResult Index(Models.UserProfile userProfile)
        {
            int userAge = userProfile.Age;

            // System.DateTime.Now.Year is returning the year 2024, hence the -1
            int yearIfHadBDay = System.DateTime.Now.Year -1 -userAge;
            int yearIfNoBDay = yearIfHadBDay++;

            // Using viewbag to store values that populate the html content for the profile section
            ViewBag.Description = $"{userProfile.FirstName}/{userProfile.LastName},{userProfile.Age},{userProfile.Occupation}";
            ViewBag.RandomQuote = MovieQuoteDatabase.GetRandomQuote();
            ViewBag.EstimatedBirthYear = $"If you had your birthday this year, I think you were born in {yearIfHadBDay}, otherwise you were born in {yearIfNoBDay}";

            return View();
        }
    }
}
