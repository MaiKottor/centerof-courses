using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class AdminController : Controller
    {
        CategoryBLL cbll = new CategoryBLL();
        // GET: AdminArea/Admin
        public ActionResult Index()
        {
            List<CategoryVM> categs = cbll.getAllCategs();

            return View(categs);
        }
    }
}