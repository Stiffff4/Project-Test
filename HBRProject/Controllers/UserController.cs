using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccesss.Interfaces;
using DataAccesss.InterfaceImplementations;
using DataAccesss.Models;

namespace HBRProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers iUsers = new UsersImplementation();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUser(Users user)
        {
            try
            {
                iUsers.Create(user);
                return True();
            }
            catch(Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult GetUser(string username)
        {
            try
            {
                List<Users> userData = iUsers.GetUserList(username);
                return Json(new { data = userData, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult Login(Users user)
        {
            try
            {
                if (iUsers.IsUserValid(user))
                {
                    return True();
                }
            }
            catch(Exception e)
            {
                return Error(e, false);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUser(Users user)
        {
            try
            {
                iUsers.Update(user);
                return True();
            }
            catch(Exception e)
            {
                return Error(e, false);
            }
        }

        public JsonResult True()
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Error(Exception e, bool success)
        {
            return Json(new { errorMessage = e.Message.ToString(), success}, JsonRequestBehavior.AllowGet);
        }
    }
}