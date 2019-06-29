using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
    public class CourseBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();

        //adding a course
        public void AddCourse(CourseVM courseVM)
        {
            course courseToAdd = new course();
            courseToAdd.course_name = courseVM.course_name;
            courseToAdd.appointments = courseVM.appointments;
            courseToAdd.description = courseVM.description;
            courseToAdd.hours_number = courseVM.hours_number;
            courseToAdd.price = courseVM.price;
            courseToAdd.starting_date = courseVM.starting_date;

            courseToAdd.category_id = courseVM.category_id;
            courseToAdd.instructor_id = courseVM.instructor_id;
            courseToAdd.isActive = courseVM.isActive;
            courseToAdd.service_id = courseVM.service_id; 

            MCDB.courses.Add(courseToAdd);
            MCDB.SaveChanges();
        }

        //getting courses
        public List<CourseVM> getAllCourses()
        {
            List<CourseVM> courses = new List<CourseVM>();

            List<course> coursesFromDB = MCDB.courses.ToList();
            foreach (var item in coursesFromDB)
            {
                CourseVM course = new CourseVM();
                course.courses_category = item.courses_category;
                course.course_id = item.course_id;
                course.instructor_id = item.instructor_id;
                course.instructor = item.instructor;
                course.course_name = item.course_name;
                course.description = item.description;
                course.appointments = item.appointments;
                course.hours_number = item.hours_number;
                course.price = item.price;
                course.service_id = item.service_id;
                course.service = item.service;
                course.isActive = item.isActive;
                course.starting_date = item.starting_date;

                courses.Add(course);
            }
            return courses;
        }

        public CourseVM getCourseById(int id)
        {
            course courseToGet = MCDB.courses.Where(x => x.course_id == id).FirstOrDefault();
            CourseVM courseVM = new CourseVM();
            if (courseToGet != null)
            {
                courseVM.course_id = courseToGet.course_id;
                courseVM.category_id = courseToGet.category_id;
                courseVM.courses_category = courseToGet.courses_category;
                courseVM.appointments = courseToGet.appointments;
                courseVM.course_name = courseToGet.course_name;
                courseVM.description = courseToGet.description;
                courseVM.hours_number = courseToGet.hours_number;
                courseVM.instructor_id = courseToGet.instructor_id;
                courseVM.isActive = courseToGet.isActive;
                courseVM.price = courseToGet.price;
                courseVM.service_id = courseToGet.service_id;
                courseVM.starting_date = courseToGet.starting_date;

                return courseVM;
            }
            else
            {
                return null;
            }
        }


        //updating course
        public void UpdateCourse(CourseVM course)
        {
            course courseToUpdate = MCDB.courses.FirstOrDefault(x => x.course_id == course.course_id);
            //MCDB.Entry(courseToDelete).State = System.Data.Entity.EntityState.Modified;
            courseToUpdate.appointments = course.appointments;
            courseToUpdate.category_id = course.category_id;
            courseToUpdate.course_name = course.course_name;
            courseToUpdate.description = course.description;
            courseToUpdate.hours_number = course.hours_number;
            courseToUpdate.instructor_id = course.instructor_id;
            courseToUpdate.isActive = course.isActive;
            courseToUpdate.price = course.price;
            courseToUpdate.service_id = course.service_id;
            courseToUpdate.starting_date = course.starting_date;
            
            MCDB.SaveChanges();

        }

        //delete course
        public void DeleteCourse(int id)
        {
            course courseToDelete = MCDB.courses.Where(x => x.course_id == id).FirstOrDefault();
            MCDB.courses.Remove(courseToDelete);
            MCDB.SaveChanges();
        }

        //get all categories
        public List<CategoryVM> getAllCategories()
        {
            List<CategoryVM> categs = new List<CategoryVM>();
            var categories = MCDB.courses_category.ToList();
            foreach (var item in categories)
            {
                CategoryVM category = new CategoryVM();
                category.category_id = item.category_id;
                category.category_name = item.category_name;
                categs.Add(category);
            }

            return categs;
        }

        //get active courses
        public List<CourseVM> GetActiveCourses()
        {
            List<CourseVM> activeCourses = new List<CourseVM>();
            var coursesToGet = MCDB.courses.Where(x => x.isActive == true).ToList();

            foreach (var item in coursesToGet)
            {
                CourseVM activeCourse = new CourseVM();
                activeCourse.appointments = item.appointments;
                activeCourse.category_id = item.category_id;
                activeCourse.course_id = item.course_id;
                activeCourse.course_name = item.course_name;
                activeCourse.description = item.description;
                activeCourse.hours_number = item.hours_number;
                activeCourse.instructor_id = item.instructor_id;
                activeCourse.isActive = item.isActive;
                activeCourse.price = item.price;
                activeCourse.service_id = item.service_id;
                activeCourse.starting_date = item.starting_date;

                activeCourses.Add(activeCourse);
            }

            return activeCourses;
        }

        //get courses by category id
        public List<CourseVM> GetCoursesByCategId(int id)
        {
            List<CourseVM> coursesByCategId = new List<CourseVM>();
            var coursesToGet = MCDB.courses.Where(x => x.category_id == id).ToList();

            foreach (var item in coursesToGet)
            {
                CourseVM activeCourse = new CourseVM();
                activeCourse.appointments = item.appointments;
                activeCourse.category_id = item.category_id;
                activeCourse.course_id = item.course_id;
                activeCourse.course_name = item.course_name;
                activeCourse.description = item.description;
                activeCourse.hours_number = item.hours_number;
                activeCourse.instructor_id = item.instructor_id;
                activeCourse.isActive = item.isActive;
                activeCourse.price = item.price;
                activeCourse.service_id = item.service_id;
                activeCourse.starting_date = item.starting_date;

                coursesByCategId.Add(activeCourse);
            }

            return coursesByCategId;
        }

        public List<countStudentIncoursesVM> getStudentNumberByCourse()
        {
            //    var xx = (from x in MCDB.user_course group x by x.course_id into g select new { a = g.Key, b = g.ToList() });

            var y = MCDB.user_course.ToList();
            var xx = from s in y group s by s.course_id;

            List<countStudentIncoursesVM> listvm = new List<countStudentIncoursesVM>();


            int courseid = 0;
            int count = 0;
            string courseName = "";
            foreach (var item in xx)
            {
                countStudentIncoursesVM newv = new countStudentIncoursesVM();

                courseid = item.Key;
                courseName = getCourseById(courseid).course_name;
                count = item.Count();

                newv.courseid = courseid;
                newv.courseName = courseName;
                newv.count = count;
                listvm.Add(newv);
            }
            return listvm;
        }
    }
}
