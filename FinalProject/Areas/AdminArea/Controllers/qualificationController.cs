using FinalProject.BLL.BusinessLayers;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class qualificationController : Controller
    {
        QualificationBll _qualificationBLL = new QualificationBll();

        // GET: AdminArea/qualification
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AddNewQualification()
        {
            List<qualificationVM> qualifications = _qualificationBLL.getAllQualifications();
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddNewQualification(qualificationVM qualificationsVM)
        {
            _qualificationBLL.AddQualification(qualificationsVM);
            return RedirectToAction("getAllQualifications", "qualification", new { area = "AdminArea" });
        }
        //SELECT *
        public ActionResult getAllQualifications()
        {
            List<qualificationVM> qualifications = _qualificationBLL.getAllQualifications();
            return View(qualifications);
            //ViewBag.news = _news.getAllNews();
            //ViewBag.newsTypes = _types.getAllnewsTypes();
            //r
        }
        //DELETE
        public ActionResult DeleteQualificaions(int id)
        {
            _qualificationBLL.DeleteQualification(id);
            List<qualificationVM> qualifications = _qualificationBLL.getAllQualifications();
            ViewBag.qualifications = qualifications;
            return RedirectToAction("getAllQualifications", "qualification");
        }
        [HttpGet]
        public ActionResult EditQualificationa(int id)
        {
            qualificationVM qualifics = _qualificationBLL.getQualificssById(id);
            return PartialView(qualifics);
        }
        [HttpPost]
        public ActionResult EditQualificationa(qualificationVM qsvm)
        {
            _qualificationBLL.UpdateQualifications(qsvm);
            List<qualificationVM> qualifics = _qualificationBLL.getAllQualifications();
            ViewBag.qualifics = qualifics;
            return RedirectToAction("getAllQualifications", "qualification", new { area = "AdminArea" });
        }
    }
}