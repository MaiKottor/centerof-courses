using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
    public class UserCoursesBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();
        public bool RegisterThisCourse(int courseId, int userId)
        {
            user_course userCourse = new user_course();
            userCourse.course_id = courseId;
            userCourse.user_id = userId;

            if (!isRegistered(courseId, userId))
            {
                MCDB.user_course.Add(userCourse);
                MCDB.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }

        }


        public bool isRegistered(int courseId, int userId)
        {
            user_course userCourse = MCDB.user_course.FirstOrDefault(x => x.course_id == courseId && x.user_id == userId);
            if (userCourse != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
