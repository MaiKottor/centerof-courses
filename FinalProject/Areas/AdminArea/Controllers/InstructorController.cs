using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using FinalProject.DAL;
 
namespace FinalProject.Areas.AdminArea.Controllers
{
    public class InstructorController : Controller
    {
        // GET: AdminArea/Instructor
        // GET: Employee
        public ActionResult index()
        {  
            return View();  
        }
        public ActionResult GetAllInstructors()
        {
            ViewBag.Istructors = InstructorBll.getAllIstructors();
            return PartialView("GetAllInstructors");
        }
        public ActionResult AddInstructor()
        {
            return PartialView("instructorPartial");
            
        }
        [HttpPost]
        public ActionResult AddInstructor(instructorVM instructorvm)
        {
            //if (ModelState.IsValid == true)
            //{
                InstructorBll.AddInstructor(instructorvm);
                ViewBag.Istructors = InstructorBll.getAllIstructors();
           // }
                return RedirectToAction("index", "Instructor", new { area = "AdminArea" });
            
        }
        public ActionResult Edit(int id)
        {
          instructorVM insvm=  InstructorBll.getInstructorByID2(id);
            //return View(insvm);
            return PartialView("editInstructor", insvm);
        }
        [HttpPost]
        public ActionResult Edit(instructorVM instructorvm)
        {
            InstructorBll.UpdateInstructor(instructorvm);

            ViewBag.Istructors = InstructorBll.getAllIstructors();
           
            return RedirectToAction("index","Instructor", new { area = "AdminArea" });
        }
        
        public ActionResult delete(int id)
        {
            InstructorBll.DeleteInstructor(id);

            ViewBag.Istructors = InstructorBll.getAllIstructors();
            return RedirectToAction("index", "Instructor", new { area = "AdminArea" });
        }

    }
}