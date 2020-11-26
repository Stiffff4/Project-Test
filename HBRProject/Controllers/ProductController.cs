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
    public class ProductController : Controller
    {
        private readonly IProducts iProducts = new ProductsImplementation(); 

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            try
            {
                List<Products> allProducts = iProducts.Retrieve();
                return Json(new { data = allProducts, success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult CreateProduct(Products product)
        {
            try
            {
                iProducts.Create(product);
                return True();
            }
            catch (Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult UpdateProduct(Products product)
        {
            try
            {
                iProducts.Update(product);
                return True();
            }
            catch (Exception e)
            {
                return Error(e, false);
            }
        }

        [HttpPost]
        public JsonResult DeleteProduct(Products product)
        {
            try
            {
                iProducts.Delete(product);
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