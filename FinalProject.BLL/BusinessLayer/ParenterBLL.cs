using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.BLL.BusinessLayer
{
   public class ParenterBLL
    {

        MCenterDBContext db = new MCenterDBContext();

        public List<parenterVM> getAllParenters()
        {
            List<parenterVM> myparenters = new List<parenterVM>();
            var parenter = db.parenters.ToList();

            foreach (var item in parenter)
            {
                parenterVM parenterobj = new parenterVM();
                parenterobj.email= item.email;
                parenterobj.parenter_id = item.parenter_id;
                parenterobj.Mobile = item.Mobile;
                parenterobj.phone = item.phone;
               parenterobj.parenter_name = item.parenter_name;
                parenterobj.image= item.image;





                myparenters.Add(parenterobj);
            }

            return myparenters;
        }

        //adding a parenter
        public void AddParenter(parenterVM parentvm)
        {
            parenter parenterToAdd = new parenter();
            parenterToAdd.email = parentvm.email;
            parenterToAdd.parenter_id = parentvm.parenter_id;
            parenterToAdd.Mobile = parentvm.Mobile;
            parenterToAdd.phone = parentvm.phone;
            parenterToAdd.parenter_name = parentvm.parenter_name;

            parenterToAdd.image = parentvm.image;


            db.parenters.Add(parenterToAdd);
            db.SaveChanges();
        }

        //rempve parenter
        public void deleteparenter(int id)
        {
            parenter parentertodelete = db.parenters.Where(a => a.parenter_id == id).FirstOrDefault();
            db.parenters.Remove(parentertodelete);
            db.SaveChanges();
        }

        // get lab by id 

        public parenterVM getParenterById(int id)
        {
            parenter myparenter = db.parenters.Where(a => a.parenter_id == id).FirstOrDefault();
            parenterVM parentervm = new parenterVM();
            if  (myparenter != null)
            {
                parentervm.email = myparenter.email;
                parentervm.parenter_id = myparenter.parenter_id;
                parentervm.Mobile = myparenter.Mobile;
                parentervm.phone = myparenter.phone;
                parentervm.parenter_name = myparenter.parenter_name;
                parentervm.image = myparenter.image;

               
                return parentervm;
            }
            else
            {
                return null;
            }
        }

        public void updateparenter(parenterVM parentvm)
        {
            parenter parenterToupdate = db.parenters.Where(a => a.parenter_id ==parentvm.parenter_id).FirstOrDefault();
            parenterToupdate.email = parentvm.email;
            parenterToupdate.parenter_id = parentvm.parenter_id;
            parenterToupdate.Mobile = parentvm.Mobile;
            parenterToupdate.phone = parentvm.phone;
            parenterToupdate.parenter_name = parentvm.parenter_name;
            parenterToupdate.image = parentvm.image;
            db.SaveChanges();
        }

    }
}
