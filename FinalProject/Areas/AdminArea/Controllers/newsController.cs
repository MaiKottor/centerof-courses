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
    public class newsController : Controller
    {
        newsBLL _news = new newsBLL();
        newsTypeBLL _types = new newsTypeBLL();
        // GET: AdminArea/news
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNews()
        {
            List<newsTypeVM> news_types = _types.getAllnewsTypes();
            SelectList typeList = new SelectList(news_types, "type_id", "type_name");
            ViewBag.newsTypes = typeList;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddNews(newsVM newsvm, HttpPostedFileBase img)
        {
            string extention = img.FileName.Substring(img.FileName.LastIndexOf("."));
            string fName = newsvm.news_id.ToString() + extention;
            img.SaveAs(Server.MapPath("~/Images/") + fName);
            newsvm.image = fName;
            _news.AddNews(newsvm);
            return RedirectToAction("getAllNews", "news", new { area = "AdminArea" });
        }
        //SELECT *
        public ActionResult getAllNews()
        {
            List<newsVM> news = _news.getAllNews();
            return View(news);


            //ViewBag.news = _news.getAllNews();
            //ViewBag.newsTypes = _types.getAllnewsTypes();
            //return View();
        }
        //DELETE
        public ActionResult DeleteNews(int id)
        {
            _news.DeleteNews(id);
            List<newsVM> news = _news.getAllNews();
            ViewBag.news = news;
            return RedirectToAction("getAllNews", "news");
        }
        [HttpGet]
        public ActionResult EditNews(int id)
        {
            newsVM news = _news.getNewsById(id);

            List<newsTypeVM> types = _types.getAllnewsTypes();
            SelectList typeslist = new SelectList(types, "type_id", "type_name", news.news_id);
            ViewBag.typeslist = typeslist;

            return PartialView(news);
        }

        [HttpPost]
        public ActionResult EditNews(newsVM nvm, HttpPostedFileBase img)
        {
            if (img != null)
            {
                string extention = img.FileName.Substring(img.FileName.LastIndexOf("."));
                string fName = nvm.news_id.ToString() + extention;
                img.SaveAs(Server.MapPath("~/Images/") + fName);
                nvm.image = fName;
            }

            _news.UpdateNews(nvm);
            List<newsVM> news = _news.getAllNews();
            ViewBag.news = news;
            return RedirectToAction("getAllNews", "news", new { area = "AdminArea" });
        }

    }
}