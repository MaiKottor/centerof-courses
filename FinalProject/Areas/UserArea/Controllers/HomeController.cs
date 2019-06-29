using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.BusinessLayers;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.UserArea.Controllers
{
   
    public class HomeController : Controller
    {

        QualificationBll qualificationbll = new QualificationBll();
        UsersBll userbll = new UsersBll();
        // GET: UserArea/Home
        public ActionResult Index()
        {

            CourseBLL cbll = new CourseBLL();
            List<CourseVM> mylist = cbll.getAllCourses();
            SelectList li = new SelectList(mylist, "course_id", "course_name");
            ViewBag.li = li;

            return View();
        }

        public ActionResult service()
        {
            servicesBLL sbll = new servicesBLL();
            List<servicesVM> mylist = sbll.gettopservice();
            return PartialView(mylist);
        }

        public ActionResult parenter()
        {
            return PartialView();
        }
        public ActionResult news()
        {
            newsBLL nbll = new newsBLL();
            List<newsVM> mylist = nbll.gettopnews();
            return PartialView(mylist);
        }
        public ActionResult getclients()
        {

            ParenterBLL pbll = new ParenterBLL();
            List<parenterVM> mylist = pbll.getAllParenters();
            return PartialView(mylist);
        }
        // Register & login 

        public ActionResult Register()
        {
            List<qualificationVM> lstQualifications = qualificationbll.getQualifications();
            SelectList QualificationList = new SelectList(lstQualifications, "qualification_id", "qualification_name");
            ViewBag.QualificationList = QualificationList;
            return View();
        }
        [HttpPost]
        public ActionResult Register(UsersVM user)
        {
            // if (ModelState.IsValid)
            //  { 

            bool isAdded = userbll.AddUser(user);
            if (isAdded)
            {

                Session["user_id"] = user.user_id;

                List<qualificationVM> lstQualifications = qualificationbll.getQualifications();
                SelectList QualificationList = new SelectList(lstQualifications, "qualification_id", "qualification_name");
                ViewBag.QualificationList = QualificationList;

                return RedirectToAction("LoginUser", "Home", new { area = "UserArea" });
            }
            else
            {
                ViewBag.exist = false;
                return RedirectToAction("Register", "Home", new { area = "UserArea" });
            }
        }
        //public ActionResult getAllRegisters()
        //{
        //    List<UsersVM> users = userbll.getAllUsers();
        //    return View(users);
        //}
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LoginVM login)
        {
            if (userbll.checkUserLogin(login) != null)
            {
                var user = userbll.checkUserLogin(login);
                Session["user_id"] = user.user_id;
                var role = user.role;
                if (role == true)
                {
                    return RedirectToAction("getAllCourses", "Course", new { area = "AdminArea" });
                }
                int user_id = int.Parse(Session["user_id"].ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginUser", "Home");
            }
        }
        public ActionResult SignUserOut()
        {
            if (Session["user_id"] != null)
            {
                Session["user_id"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("profile", "Home");
            }


        }



        public ActionResult profile()
        {
            if (Session["user_id"] == null)
            {

                return RedirectToAction("LoginUser", "Home");

            }
            else
            {
                int id = int.Parse(Session["user_id"].ToString());
                UsersVM user = userbll.getUserByID2(id);
                return View(user);
            }
        }
        public ActionResult checkUserName(string loginuserName, int user_id)
        {
            // if (userbll.getUserBYName(loginuserName) == null)
            if (userbll.getUserByID(user_id) == null)//check if it creat only
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }
}