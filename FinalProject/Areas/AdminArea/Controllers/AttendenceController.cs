using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class AttendenceController : Controller
    {
        CourseBLL courseBLL = new CourseBLL();
        AttendenceBLL attendenceBLL = new AttendenceBLL();
        // GET: AdminArea/Attendence
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAttendence()
        {
            List<CourseVM> activeCourses = courseBLL.GetActiveCourses();
            SelectList activeCoursesList = new SelectList(activeCourses, "course_id", "course_name");
            ViewBag.activeCoursesList = activeCoursesList;

            return View();
        }

        public ActionResult GetCourseStudents(int id)
        {
           
            foreach (int item in attendenceBLL.getStudentByCourseId(id))
            {
                attendenceBLL.addAttendance(id, item);
            }

           //attendenceBLL.getAttendanceByCurrentDate(DateTime.Now);
            // List<Course_AttendenceVM> courseStudents = attendenceBLL.GetAssignedStudents(id);

            return PartialView("GetCourseStudents",attendenceBLL.getAttendanceByCurrentDate(DateTime.Now,id));
        }
        public void registerAtt(int id)
        {
            int courseId = id;
            int st=Convert.ToInt32( Request.QueryString["studentid"]);
            bool att=attendenceBLL.setAttendanceforStudent(courseId, st, DateTime.Now);
            
            //if (att == true)
            //{
            //   return Content("تم تسجبل الحضور");
            //}
            //else
            //{
            //    return Content("تم تسجبل الحضور من قبل ");
            //}            
        }

        public void registerdeparture(int id)
        {
            int courseId = id;
            int st = Convert.ToInt32(Request.QueryString["studentid"]);
            bool att = attendenceBLL.setdepartureforStudent(courseId, st, DateTime.Now);
            //if (att == true)
            //{
            //    return Content("تم تسجبل الانصراف");
            //}
            //else
            //{
            //    return Content("تم تسجبل الانصراف من قبل ");
            //}
        }

    }
}