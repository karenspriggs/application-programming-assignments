using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserProfileApp2.Models;

namespace UserProfileApp2.Controllers
{
    public class UserController : Controller
    {
        UserProfileService userProfileService = new UserProfileService();

        // GET: User/Details/5
        public ActionResult Details()
        {
            return View(userProfileService.GetUserProfileWithID(userProfileService.GetCurrentID()));
        }

        // GET: User/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                UserProfile newUser = new UserProfile();

                newUser.FirstName = collection["FirstName"];
                newUser.LastName = collection["LastName"];
                newUser.Occupation = collection["Occupation"];

                int age;
                bool success =  Int32.TryParse(collection["Age"], out age);

                if (success)
                {
                    newUser.Age = age;
                } else
                {
                    newUser.Age = 0;
                }

                userProfileService.AddUserProfile(newUser);

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
