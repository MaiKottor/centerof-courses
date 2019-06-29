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
    public class ParenterController : Controller
    {
        ParenterBLL bll = new ParenterBLL();
        // GET: AdminArea/Parenter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getparenters()
        {
            List<parenterVM> allparenters = bll.getAllParenters();
            return View(allparenters);

        }

        public ActionResult Addparenter()
        {
          
            return PartialView();
        }

        [HttpPost]
        public ActionResult Addparenter(parenterVM parentervm,HttpPostedFileBase img)
        {
            string extention = img.FileName.Substring(img.FileName.LastIndexOf("."));
            string fName = parentervm.parenter_id.ToString() + extention;
            img.SaveAs(Server.MapPath("~/Images/") + fName);
            parentervm.image = fName;

            bll.AddParenter(parentervm);
            return RedirectToAction("getparenters", "Parenter", new { area = "AdminArea" });
        }
        public ActionResult remove(int id)

        {
            bll.deleteparenter(id);
            return RedirectToAction("getparenters", "Parenter", new { area = "AdminArea" });
        }
        public ActionResult editparenter(int id)
        {
            parenterVM parentertoedit = bll.getParenterById(id);
          
            return PartialView(parentertoedit);
        }
        [HttpPost]
        public ActionResult editparenter(parenterVM parentervm,HttpPostedFileBase img)
        {

         


            if (img != null)
            {
                string extention = img.FileName.Substring(img.FileName.LastIndexOf("."));
                string fName = parentervm.parenter_id.ToString() + extention;
                img.SaveAs(Server.MapPath("~/Images/") + fName);
                parentervm.image = fName;
            }

            bll.updateparenter(parentervm);
            List<parenterVM> parents = bll.getAllParenters();
            ViewBag.news = parents;
            return RedirectToAction("getparenters", "parenter", new { area = "AdminArea" });

        }

    }
}