﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthorizationExample;
using AuthorizationExample.Services;

namespace AuthorizationExample.Controllers
{
    public class UsersController : Controller
    {
        private PROG455FA23Entities db = new PROG455FA23Entities();
        UserService userService = new UserService();
        AuthService authService = new AuthService();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["LoggedIn"]?.Equals(true) == true)
            {
                return RedirectToAction("UserList");
            }

            return View();
        }

        public ActionResult UserList()
        {
            User currentUser = userService.GetUser((string)Session["Username"]);

            if (!authService.IsPageAuthorized("List", currentUser))
            {
                return RedirectToAction("AccessDenied");
            }

            return View(userService.ReturnUserList());
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userService.FindUserWithID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Login
        public ActionResult Login()
        {
            // Check if authorized, redirect to index if true
            // Otherwise go back to login page
            if (Session["LoggedIn"]?.Equals(true) == true)
            {
                return RedirectToAction("UserList");
            }

            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            bool isSuccessfulLogin = userService.IsValidPassword(user.Username, user.Password);

            if (isSuccessfulLogin)
            {
                ViewBag.Message = "Login successful!";
                Session.Add("LoggedIn", true);
                Session.Add("Username", user.Username);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid login credentials, please try again.";
                Session.Add("LoggedIn", false);
            }

            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User currentUser = userService.GetUser((string)Session["Username"]);

            if (!authService.IsPageAuthorized("Create", currentUser))
            {
                return RedirectToAction("AccessDenied");
            }

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,First_Name,Last_Name,Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            User currentUser = userService.GetUser((string)Session["Username"]);

            if (!authService.IsPageAuthorized("Edit", currentUser))
            {
                return RedirectToAction("AccessDenied");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userService.FindUserWithID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,First_Name,Last_Name,Username,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                userService.EditUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            User currentUser = userService.GetUser((string)Session["Username"]);

            if (!authService.IsPageAuthorized("Delete", currentUser))
            {
                return RedirectToAction("AccessDenied");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user =userService.FindUserWithID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            userService.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
