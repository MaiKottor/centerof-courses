using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.BusinessLayers;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class UsersController : Controller
    {
        QualificationBll qualificationbll = new QualificationBll();
        UsersBll userbll = new UsersBll();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
          List<qualificationVM> lstQualifications= qualificationbll.getQualifications();
          SelectList QualificationList = new SelectList(lstQualifications, "qualification_id", "qualification_name");
            ViewBag.QualificationList = QualificationList;
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsersVM user)
        {
            if (ModelState.IsValid)
            {

                userbll.AddUser(user);
            }
            List<qualificationVM> lstQualifications = qualificationbll.getQualifications();
            SelectList QualificationList = new SelectList(lstQualifications, "qualification_id", "qualification_name");
            ViewBag.QualificationList = QualificationList; return View();
        }
        public ActionResult checkUserName(string loginuserName,int user_id)
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

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(LoginVM login)
        {
          if(userbll.checkUserLogin(login) !=null)
            return RedirectToAction("Index", "Users");
            else return RedirectToAction("login", "Users");
        }
    }
}