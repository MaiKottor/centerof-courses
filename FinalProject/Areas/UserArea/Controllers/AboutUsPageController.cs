using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.UserArea.Controllers
{
    public class AboutUsPageController : Controller
    {
        // GET: UserArea/AboutUsPage
        public ActionResult Index()
        {
            CourseBLL cbll = new CourseBLL();
            List<CourseVM> mylist = cbll.getAllCourses();
            SelectList li = new SelectList(mylist, "course_id", "course_name");
            ViewBag.li = li;
            return View();
        }
    }
}