using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class news_typeController : Controller
    {
        newsTypeBLL _newsTypeBLL = new newsTypeBLL();
        // GET: AdminArea/news_type
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult AddNewsType()
        {
            List<newsTypeVM> types = _newsTypeBLL.getAllnewsTypes();
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddNewsType(newsTypeVM newsTypesVM)
        {
            _newsTypeBLL.AddNewsType(newsTypesVM);
            return RedirectToAction("getAllNewsTypes", "news_type", new { area = "AdminArea" });
        }






        //SELECT *
        public ActionResult getAllNewsTypes()
        {
            List<newsTypeVM> newsTypes = _newsTypeBLL.getAllnewsTypes();
            return View(newsTypes);
            //ViewBag.news = _news.getAllNews();
            //ViewBag.newsTypes = _types.getAllnewsTypes();
            //r
        }
        //DELETE
        public ActionResult DeleteNewsType(int id)
        {
            _newsTypeBLL.DeleteNewsType(id);
            List<newsTypeVM> newsTypes = _newsTypeBLL.getAllnewsTypes();
            ViewBag.newsTypes = newsTypes;
            return RedirectToAction("getAllNewsTypes", "news_type");
        }
        [HttpGet]
        public ActionResult EditNewsTypes(int id)
        {
            newsTypeVM newsTypes = _newsTypeBLL.getNewsTypeById(id);
            return PartialView(newsTypes);
        }
        [HttpPost]
        public ActionResult EditNewsTypes(newsTypeVM ntvm)
        {
            _newsTypeBLL.UpdateNewsTypes(ntvm);
            List<newsTypeVM> newsTypes = _newsTypeBLL.getAllnewsTypes();
            ViewBag.newsTypes = newsTypes;
            return RedirectToAction("getAllNewsTypes", "news_type", new { area = "AdminArea" });
        }
    }
}