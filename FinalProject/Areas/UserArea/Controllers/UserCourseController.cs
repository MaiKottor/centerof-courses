using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.UserArea.Controllers
{
    public class UserCourseController : Controller
    {
        CourseBLL courseBll = new CourseBLL();
        CategoryBLL categBll = new CategoryBLL();
        UserCoursesBLL userCoursesBll = new UserCoursesBLL();

        // GET: UserArea/UserCourse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategsCourses()
        {
            CoursesCategsVM ccvm = new CoursesCategsVM();

            List<CategoryVM> categs = categBll.getAllCategs();
            ccvm.categs = categs;

            List<CourseVM> courses = courseBll.getAllCourses();
            ccvm.courses = courses;



            return View(ccvm);
        }

        public ActionResult GetCoursesByCategoryId(int id)
        {
            List<CourseVM> courses = courseBll.GetCoursesByCategId(id);
            return PartialView(courses);
        }

        public ActionResult GetAllCourses()
        {
            List<CourseVM> courses = courseBll.getAllCourses();
            return PartialView(courses);
        }

        public ActionResult RegisterThisCourse(int id)
        {
            if (Session["user_id"] != null)
            {
                int userId = int.Parse(Session["user_id"].ToString());
                bool isRegistered = userCoursesBll.RegisterThisCourse(id, userId);

                if (!isRegistered)
                {
                    ViewBag.registered = true;
                }
                else
                {
                    ViewBag.registered = false;
                }
                return RedirectToAction("GetCategsCourses");    
            }
            else
            {
                return RedirectToAction("LoginUser", "Home");
            }
        }
    }
}