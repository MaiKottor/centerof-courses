using System;
using System.Linq;
using System.Web.Mvc;
using FinalProject.BLL.BusinessLayer;
using FinalProject.BLL.ViewModels;
using System.Linq.Dynamic;
using System.Collections.Generic;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class ReportsController : Controller
    {
        // GET: AdminArea/Reports
        public ActionResult ShowGrid()
        {
            return View();
        }
        public ActionResult LoadData()
        {
            try
            {
                //Creating instance of DatabaseContext class  
                
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                    //Paging Size (10,20,50,100)    
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordsTotal = 0;

                    // Getting all Customer data    
                    //var customerData = (from tempcustomer in _context.Customers select tempcustomer);
                    IEnumerable<instructorVM>  customerData= InstructorBll.getAllIstructors();
                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                    }
                    //Search    
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        customerData = customerData.Where(m => m.instructor_name .Contains (searchValue));
                    }

                    //total number of rows count     
                    recordsTotal = customerData.Count();
                    //Paging     
                    var data = customerData.Skip(skip).Take(pageSize).ToList();
                    //Returning Json Data    
                    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult ShowCoursesReport()
        {
            return View();
        }
        public ActionResult LoadCoursesReport()
        {
            CourseBLL cbll = new CourseBLL();
            try
            {
                //Creating instance of DatabaseContext class  

                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                //var customerData = (from tempcustomer in _context.Customers select tempcustomer);
                IEnumerable<countStudentIncoursesVM> customerData = cbll.getStudentNumberByCourse();
                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.courseName.Contains(searchValue));
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            instructorVM insvm = InstructorBll.getInstructorByID2(id);
            return View(insvm);
            
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
               InstructorBll.DeleteInstructor(id);
                return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
 
            }

        }
    }



    