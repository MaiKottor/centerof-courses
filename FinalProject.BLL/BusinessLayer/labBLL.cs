using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
  public class labBLL
    {
        MCenterDBContext db = new MCenterDBContext();

        public List<labVM> getAllLabs()
        {
            List<labVM> mylabs = new List<labVM>();
            var lab = db.labs.ToList();

            foreach (var item in lab)
            {
                labVM lbobj = new labVM();
                lbobj.lab_id = item.lab_id;
                lbobj.lab_name = item.lab_name;
                lbobj.lab_number = item.lab_number;
                lbobj.description = item.description;
                lbobj.floor_number = item.floor_number;
                lbobj.service_id = item.service_id;




               mylabs.Add(lbobj);
            }

            return mylabs;
        }

        //adding a lab
        public void AddLab(labVM labVM)
        {
            lab labToAdd = new lab();
            labToAdd.lab_name = labVM.lab_name;
            labToAdd.lab_number= labVM.lab_number;
            labToAdd.description = labVM.description;
            labToAdd.floor_number = labVM.floor_number;
            labToAdd.service_id = labVM.service_id;
          
            db.labs.Add(labToAdd);
           db.SaveChanges();
        }

        //rempve lab 
        public void deletelab(int id)
        {
            lab labtodelete = db.labs.Where(a => a.lab_id == id).FirstOrDefault();
            db.labs.Remove(labtodelete);
            db.SaveChanges();
        }

        // get lab by id 

        public labVM getLabById(int id)
        {
            lab mylab = db.labs.Where(a => a.lab_id == id).FirstOrDefault();
            labVM labvm = new labVM();
            if (mylab != null)
            {
                labvm.lab_id = mylab.lab_id;
                labvm.lab_name = mylab.lab_name;
                labvm.description = mylab.description;
                labvm.floor_number = mylab.floor_number;
                labvm.service_id = mylab.service_id;
                labvm.lab_number = mylab.lab_number;
                return labvm;
            }
            else
            {
                return null;
            }
        }

        // update data 
        public void updateLab(labVM labvm)
        {
            lab labtoupdate = db.labs.Where(a => a.lab_id == labvm.lab_id).FirstOrDefault();
            labtoupdate.lab_name = labvm.lab_name;
            labtoupdate.lab_number = labvm.lab_number;
            labtoupdate.description = labvm.description;
            labtoupdate.floor_number = labvm.floor_number;
            labtoupdate.service_id = labvm.service_id;
            db.SaveChanges();
        }

        public List<servicesVM> getAllservices()
        {
            List<servicesVM> myservice = new List<servicesVM>();
            var services = db.services.ToList();
            foreach (var item in services)
            {
                servicesVM servicev = new servicesVM();
                servicev.service_id = item.service_id;
                servicev.service_name = item.service_name;
                myservice.Add(servicev);
            }

            return myservice;
        }
    }
}
