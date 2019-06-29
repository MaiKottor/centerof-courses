using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BLL.ViewModels;
using System.Data.Entity;
using FinalProject.DAL;

namespace FinalProject.BLL.BusinessLayer
{
  public   class InstructorBll
    {
      
        public static List<instructorVM> getAllIstructors()
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {

                List<instructorVM> lstInstructors = db.instructors.Select(x =>
                new instructorVM
                {
                    instructor_name = x.instructor_name,
                    Current_JobTitle = x.Current_JobTitle,
                    TrainningTopic = x.TrainningTopic,
                    NameOf_ItsUnit = x.NameOf_ItsUnit,
                    instructor_id = x.instructor_id,
                    Mobile = x.Mobile,
                    phone = x.phone,
                    Email = x.Email,
                    QualificationsName = x.QualificationsName
                }).ToList();
                return lstInstructors;
            }

        }

        public static void AddInstructor(instructorVM instructorvm)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                instructor newInstructor = new instructor();
                newInstructor.instructor_name = instructorvm.instructor_name;
                newInstructor.NameOf_ItsUnit = instructorvm.NameOf_ItsUnit;
                newInstructor.TrainningTopic = instructorvm.TrainningTopic;
                newInstructor.Current_JobTitle = instructorvm.Current_JobTitle;
                newInstructor.Mobile = instructorvm.Mobile;
                newInstructor.phone = instructorvm.phone;
                newInstructor.Email = instructorvm.Email;
                newInstructor.QualificationsName = instructorvm.QualificationsName;

                db.instructors.Add(newInstructor);
                db.SaveChanges();
                
                
            }

        }

        public static void UpdateInstructor(instructorVM instructorvm)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                instructor updataedInstructor = getInstructorByID(instructorvm.instructor_id);
                updataedInstructor.instructor_name = instructorvm.instructor_name;
                updataedInstructor.NameOf_ItsUnit = instructorvm.NameOf_ItsUnit;
                updataedInstructor.TrainningTopic = instructorvm.TrainningTopic;
                updataedInstructor.Current_JobTitle = instructorvm.Current_JobTitle;
                updataedInstructor.Mobile = instructorvm.Mobile;
                updataedInstructor.phone = instructorvm.phone;
                updataedInstructor.Email = instructorvm.Email;
                updataedInstructor.QualificationsName = instructorvm.QualificationsName;
                db.Entry(updataedInstructor).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteInstructor(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                instructor deletedIns = getInstructorByID(id);
              //  db.instructors.Remove(deletedIns);
                db.Entry(deletedIns).State = EntityState.Deleted;
                db.SaveChanges();
                
            }
        }
        
        public static instructorVM getInstructorByID2(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
   instructorVM instructor = db.instructors.Where(x => x.instructor_id == id).Select(x =>
           new instructorVM
           {
               instructor_name = x.instructor_name,
               Current_JobTitle = x.Current_JobTitle,
               TrainningTopic = x.TrainningTopic,
               NameOf_ItsUnit = x.NameOf_ItsUnit,
               instructor_id = x.instructor_id,
                Mobile = x.Mobile,
                phone = x.phone,
                Email = x.Email,
                QualificationsName = x.QualificationsName

            }).SingleOrDefault();
                return instructor;
            }
        }
        public static instructor getInstructorByID(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                instructor instructor = db.instructors.Where(x => x.instructor_id == id).SingleOrDefault();
                return instructor;
            }
        }
    }
}
