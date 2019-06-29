using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
    public class AttendenceBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();

        public List<int> getStudentByCourseId(int courseid)
        {

          return  MCDB.user_course.Where(x => x.course_id == courseid).Select(x=>x.user_id).ToList();

        }
        public void addAttendance(int courseid,int stuid)
        {
            //check if attendace already stored in db
            List<attendance> catt = MCDB.attendances.Where(x => DbFunctions.DiffDays(x.date, DateTime.Now) == 0 && x.course_id == courseid && x.user_id==stuid).ToList();
            if (catt.Count == 0)
            {
                attendance attRec = new attendance();
                attRec.course_id = courseid;
                attRec.user_id = stuid;
                attRec.date = DateTime.Now.Date;

                MCDB.attendances.Add(attRec);
                MCDB.SaveChanges();
            }
        }
        public Boolean setAttendanceforStudent(int courseid, int studentid,DateTime date)
        {
            attendance Attendence = MCDB.attendances.Where(x => DbFunctions.DiffDays(x.date, date.Date) == 0 && x.user_id == studentid && x.course_id == courseid).FirstOrDefault();

            if (Attendence.attendant_time == null)
            {
                
                Attendence.attendant_time = DateTime.Now;
                Attendence.attendant = true;
                MCDB.SaveChanges();
                return true;
            }
            else
            {
                Attendence.attendant_time = DateTime.Now;
                Attendence.attendant_time = null;
                Attendence.attendant = false;
                MCDB.SaveChanges();
                
                return false;
            }

            //else
            //{
            //    if (DbFunctions.DiffDays(Attendence.attendant_time, DateTime.Now) > 0 || DbFunctions.DiffHours(Attendence.attendant_time, DateTime.Now) > 0 || DbFunctions.DiffMinutes(Attendence.attendant_time, DateTime.Now) > 5)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        Attendence.attendant_time = DateTime.Now;
            //        MCDB.SaveChanges();
            //        return true;
                   
            //    }

            //}

         

        }

        public Boolean setdepartureforStudent(int courseid, int studentid, DateTime date)
        {
            attendance Attendence = MCDB.attendances.Where(x => DbFunctions.DiffDays(x.date, date.Date) == 0 && x.user_id == studentid && x.course_id == courseid).FirstOrDefault();

            if (Attendence.departure_time == null)
            {
                Attendence.departure_time = DateTime.Now;
                Attendence.departure = true;
                MCDB.SaveChanges();
                return true;
            }
            else
            {
                Attendence.departure_time = DateTime.Now;
                Attendence.departure_time = null;
                Attendence.departure = false;
                MCDB.SaveChanges();
               
                return false;
            }

           
        }

        public List<AttendenceVM> getAttendanceByCurrentDate(DateTime d,int courseId)
        {
            List<AttendenceVM> lstAttendenceVM = MCDB.attendances.Where(x => DbFunctions.DiffDays(x.date,DateTime.Now)==0 && x.course_id==courseId).Select(x =>
                   new AttendenceVM
                   {
                       UserName=x.user_data.user_name,
                       attendant=x.attendant,
                       departure=x.departure,
                       attendant_time=x.attendant_time,
                       departure_time=x.departure_time,
                       courseName=x.course.course_name,
                       date = x.date,
                       course_id = x.course_id,
                       user_id=x.user_id
                   }).ToList();

            return lstAttendenceVM;
                  // List < AttendenceVM> lstAttendanceVM = MCDB.attendances.Where(X => X.date == d).ToList<AttendenceVM>();

        }

        public List<Course_AttendenceVM> GetAssignedStudents(int courseId)
        {
            List<Course_AttendenceVM> courseStudents = new List<Course_AttendenceVM>();

            var courseStudentsToGet = (from sd in MCDB.user_data
                                       join uc in MCDB.user_course on sd.user_id equals uc.user_id
                                       join c in MCDB.courses on uc.course_id equals c.course_id
                                       where c.course_id == courseId
                                    select new
                                    {
                                        user_name = sd.user_name,
                                        course_name = c.course_name,
                                    }).ToList();
            foreach (var item in courseStudentsToGet)
            {
                Course_AttendenceVM ca = new Course_AttendenceVM();
                ca.course_name = item.course_name;
                ca.user_name = item.user_name;

                courseStudents.Add(ca);
            }

            return courseStudents;
        }

        public void AddDay()
        {

        }
    }
}
