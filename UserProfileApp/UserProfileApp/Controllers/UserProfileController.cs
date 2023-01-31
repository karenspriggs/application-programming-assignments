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
            return View(new Models.UserProfile());
        }

        // POST: UserProfile/Create
        [HttpPost]
        public ActionResult Index(Models.UserProfile userProfile)
        {
            int userAge = userProfile.Age;

            //It thinks the year is 2024 when I test this, hence the -1
            int yearIfHadBDay = System.DateTime.Now.Year -1 -userAge;
            int yearIfNoBDay = yearIfHadBDay++;

            ViewBag.Description = $"{userProfile.FirstName}/{userProfile.LastName},{userProfile.Age},{userProfile.Occupation}";
            ViewBag.RandomQuote = MovieQuoteDatabase.GetRandomQuote();
            ViewBag.EstimatedBirthYear = $"If you had your birthday this year, I think you were born in {yearIfHadBDay}, otherwise you were born in {yearIfNoBDay}";

            return View(userProfile);
        }
    }
}
