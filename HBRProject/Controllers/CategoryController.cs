using System.Collections.Generic;
using System.Web.Mvc;
using DataAccesss.Interfaces;
using DataAccesss.InterfaceImplementations;
using DataAccesss.Models;
using System;

namespace HBRProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategories iCategories = new CategoriesImplementation();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            try
            {
                List<Categories> allCategories = iCategories.Retrieve();
                return Json(new { data = allCategories, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult CreateCategory(Categories category)
        {
            try
            {
                iCategories.Create(category);
                return True();
            }
            catch (Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult UpdateCategory(Categories category)
        {
            try
            {
                iCategories.Update(category);
                return True();
            }
            catch (Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult DeleteCategory(Categories category)
        {
            try
            {
                iCategories.Delete(category);

                return True();
            }
            catch (Exception e)
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
            return Json(new { errorMessage = e.Message.ToString(), success }, JsonRequestBehavior.AllowGet);
        }
    }
}