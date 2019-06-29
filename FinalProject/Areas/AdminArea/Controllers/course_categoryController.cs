using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class course_categoryController : Controller
    {
        CategoryBLL categBLL = new CategoryBLL();
        // GET: AdminArea/course_category
        public ActionResult Index()
        {
            return View();
        }





        public ActionResult AddCategory()
        {
            List<CategoryVM> catgs = categBLL.getAllCategs();
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryVM catgsVM)
        {
            categBLL.AddCategory(catgsVM);
            return RedirectToAction("getAllCatgs", "course_category", new { area = "AdminArea" });
        }



        //SELECT *
        public ActionResult getAllCatgs()
        {
            List<CategoryVM> catgs = categBLL.getAllCategs();
            return View(catgs);


            //ViewBag.news = _news.getAllNews();
            //ViewBag.newsTypes = _types.getAllnewsTypes();
            //r
        }
        //DELETE
        public ActionResult DeleteCatgs(int id)
        {
            categBLL.DeleteCatgs(id);
            List<CategoryVM> catgs = categBLL.getAllCategs();
            ViewBag.catgs = catgs;
            return RedirectToAction("getAllCatgs", "course_category");
        }
        [HttpGet]
        public ActionResult EditCatgs(int id)
        {
            CategoryVM catgs = categBLL.getCategById(id);
            return PartialView(catgs);
        }

        [HttpPost]
        public ActionResult EditCatgs(CategoryVM cvm)
        {
            categBLL.UpdateCatgs(cvm);
            List<CategoryVM> catgs = categBLL.getAllCategs();
            ViewBag.catgs = catgs;
            return RedirectToAction("getAllCatgs", "course_category", new { area = "AdminArea" });
        }
    }
}