using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class ServiceController : Controller
    {
        servicesBLL _serviceBLL = new servicesBLL();

        // GET: AdminArea/Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddServicee()
        {
            List<servicesVM> types = _serviceBLL.getAllServices();
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddServicee(servicesVM serviceVM)
        {
            _serviceBLL.AddServices(serviceVM);
            return RedirectToAction("getAllServices", "Service", new { area = "AdminArea" });
        }
        //SELECT *
        public ActionResult getAllServices()
        {
            List<servicesVM> serviceslist = _serviceBLL.getAllServices();
            return View(serviceslist);
            //ViewBag.news = _news.getAllNews();
            //ViewBag.newsTypes = _types.getAllnewsTypes();
            //r
        }
        public ActionResult DeleteService(int id)
        {
            _serviceBLL.DeleteServices(id);
            List<servicesVM> service = _serviceBLL.getAllServices();
            ViewBag.service = service;
            return RedirectToAction("getAllServices", "Service");
        }
        [HttpGet]
        public ActionResult EditService(int id)
        {
            servicesVM service = _serviceBLL.getServiceById(id);
            return PartialView(service);
        }
        [HttpPost]
        public ActionResult EditService(servicesVM svm)
        {
            _serviceBLL.UpdateNewsTypes(svm);
            List<servicesVM> service = _serviceBLL.getAllServices();
            ViewBag.service = service;
            return RedirectToAction("getAllServices", "Service", new { area = "AdminArea" });
        }
    }
}