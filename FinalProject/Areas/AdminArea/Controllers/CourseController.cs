using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class CourseController : Controller
    {
        CourseBLL courseBll = new CourseBLL();
        servicesBLL serviceBll = new servicesBLL();
        //does nothing
        public ActionResult Index()
        {
            return View();
        }

        //INSERT
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<CategoryVM> categories = courseBll.getAllCategories();
            SelectList categsList = new SelectList(categories, "category_id", "category_name");
            ViewBag.categsList = categsList;

            List<servicesVM> services = serviceBll.getAllServices();
            SelectList servicesList = new SelectList(services, "service_id", "service_name");
            ViewBag.servicesList = servicesList;

            List<instructorVM> instructors = InstructorBll.getAllIstructors();
            SelectList instructorsList = new SelectList(instructors, "instructor_id", "instructor_name");
            ViewBag.instructorsList = instructorsList;
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddCourse(CourseVM courseVM, FormCollection collection)
        {

            if (!string.IsNullOrEmpty(collection["activeState"]))
            {
                string checkResp = collection["activeState"];
                bool checkRespB = Convert.ToBoolean(checkResp);

                if (checkRespB)
                {
                    courseVM.isActive = true;
                }
                else
                {
                    courseVM.isActive = false;
                }
            }
            else
            {
                courseVM.isActive = false;
            }

            courseBll.AddCourse(courseVM);
            return RedirectToAction("getAllCourses", "Course", new { area = "AdminArea" });
        }

        //SELECT *
        public ActionResult getAllCourses()
        {
            List<CourseVM> courses = courseBll.getAllCourses();
            return View(courses);
        }

        //DELETE
        public ActionResult DeleteCourse(int id)
        {
            courseBll.DeleteCourse(id);
            List<CourseVM> courses = courseBll.getAllCourses();
            ViewBag.courses = courses;
            return RedirectToAction("getAllCourses", "Course");
        }

        //EDIT
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            CourseVM course =  courseBll.getCourseById(id);

            List<CategoryVM> categories = courseBll.getAllCategories();
            SelectList categsList = new SelectList(categories, "category_id", "category_name", course.category_id);
            ViewBag.categsList = categsList;

            List<servicesVM> services = serviceBll.getAllServices();
            SelectList servicesList = new SelectList(services, "service_id", "service_name", course.service_id);
            ViewBag.servicesList = servicesList;

            List<instructorVM> instructors = InstructorBll.getAllIstructors();
            SelectList instructorsList = new SelectList(instructors, "instructor_id", "instructor_name", course.instructor_id);
            ViewBag.instructorsList = instructorsList;

            ViewBag.activeState = course.isActive;
            return PartialView(course);
        }

        [HttpPost]
        public ActionResult EditCourse(CourseVM cvm, FormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["activeState"]))
            {
                string checkResp = collection["activeState"];
                bool checkRespB = Convert.ToBoolean(checkResp);

                if (checkRespB)
                {
                    cvm.isActive = true;
                }
                else
                {
                    cvm.isActive = false;
                }
            }
            else
            {
                cvm.isActive = false;
            }

            courseBll.UpdateCourse(cvm);
            

            List<CourseVM> courses = courseBll.getAllCourses();
            ViewBag.courses = courses;
            return RedirectToAction("getAllCourses", "Course", new { area = "AdminArea" });
        }
    }
}