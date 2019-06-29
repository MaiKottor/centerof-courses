using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class labController : Controller
    {
        labBLL bll = new labBLL();
        // GET: AdminArea/lab
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getlabs()
        {
            List<labVM> allLabs = bll.getAllLabs();
            return View(allLabs);

        }
        public ActionResult Addlab()
        {
            List<servicesVM> servicevm = bll.getAllservices();
            SelectList li = new SelectList(servicevm, "service_id", "service_name");
            ViewBag.li = li;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Addlab(labVM labvm)
        {
            bll.AddLab(labvm);
            return RedirectToAction("getlabs", "lab", new { area = "AdminArea" });
        }
        public ActionResult remove(int id)

        {
            bll.deletelab(id);
            return RedirectToAction("getlabs", "lab", new { area = "AdminArea" });
        }

        public ActionResult editlab(int id)
        {
           labVM labtoedit = bll.getLabById(id);
            List<servicesVM> servicevm = bll.getAllservices();
            SelectList li = new SelectList(servicevm, "service_id", "service_name",labtoedit.lab_id);
            ViewBag.li = li;
            return PartialView(labtoedit);
            }
        [HttpPost]
        public ActionResult editlab(labVM labvm)
        {

            bll.updateLab(labvm);
            List<labVM> labs= bll.getAllLabs();
            ViewBag.labs = labs;
            return RedirectToAction("getlabs", "lab", new { area = "AdminArea" });

        }
     

    }
}