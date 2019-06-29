using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BLL;
using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
namespace FinalProject.BLL.BusinessLayers
{
   public class QualificationBll
    {
        MCenterDBContext MCDB = new MCenterDBContext();

        //adding a course
        public void AddQualification(qualificationVM _qualficVM)
        {
            qualification qualifcToAdd = new qualification();
            qualifcToAdd.qualification_id = _qualficVM.qualification_id;
            qualifcToAdd.qualification_name = _qualficVM.qualification_name;
            qualifcToAdd.qualification_date = _qualficVM.qualification_date;
            qualifcToAdd.organization = _qualficVM.organization;
            MCDB.qualifications.Add(qualifcToAdd);
            MCDB.SaveChanges();
        }
        public List<qualificationVM> getAllQualifications()
        {

            List<qualificationVM> qualificlist = new List<qualificationVM>();

            List<qualification> qualificsFromDB = MCDB.qualifications.ToList();
            foreach (var item in qualificsFromDB)
            {
                qualificationVM qualificsvm = new qualificationVM();
                qualificsvm.qualification_id = item.qualification_id;
                qualificsvm.qualification_name = item.qualification_name;
                qualificsvm.qualification_date = item.qualification_date;
                qualificsvm.organization = item.organization;

                qualificlist.Add(qualificsvm);
            }
            return qualificlist;

        }
        public qualificationVM getQualificssById(int id)
        {
            qualification qualificsToGet = MCDB.qualifications.Where(x => x.qualification_id == id).FirstOrDefault();
            qualificationVM _qualificsVM = new qualificationVM();
            if (qualificsToGet != null)
            {
                _qualificsVM.qualification_id = qualificsToGet.qualification_id;
                _qualificsVM.qualification_name = qualificsToGet.qualification_name;
                _qualificsVM.qualification_date = qualificsToGet.qualification_date;
                _qualificsVM.organization = qualificsToGet.organization;
                return _qualificsVM;
            }
            else
            {
                return null;
            }
        }
        //updating news
        public void UpdateQualifications(qualificationVM qualifics)
        {
            qualification qualificsToUpdate = MCDB.qualifications.FirstOrDefault(x => x.qualification_id == qualifics.qualification_id);
            //MCDB.Entry(courseToDelete).State = System.Data.Entity.EntityState.Modified;
            qualificsToUpdate.qualification_id = qualifics.qualification_id;
            qualificsToUpdate.qualification_name = qualifics.qualification_name;
            qualificsToUpdate.qualification_date = qualifics.qualification_date;
            qualificsToUpdate.organization = qualifics.organization;
   
            MCDB.SaveChanges();

        }
        public void DeleteQualification(int id)
        {
            qualification qualificsToDelete = MCDB.qualifications.Where(x => x.qualification_id == id).FirstOrDefault();
            MCDB.qualifications.Remove(qualificsToDelete);
            MCDB.SaveChanges();
        }
        //fatma
        public List<qualificationVM> getQualifications()
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {

                List<qualificationVM> lstQualifiaction = db.qualifications.Select(x =>
                new qualificationVM
                {
                    qualification_name = x.qualification_name,
                    qualification_id = x.qualification_id,
                    organization = x.organization,
                    qualification_date = x.qualification_date,
                }).ToList();
                return lstQualifiaction;
            }

        }




    }
}
