using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
   public class servicesBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();
        //get all newsTypes
        public List<servicesVM> getAllServices()
        {
            List<servicesVM> servicesList = new List<servicesVM>();
            var services = MCDB.services.ToList();
            foreach (var item in services)
            {
                servicesVM servicessvm = new servicesVM();
                servicessvm.service_id = item.service_id;
                servicessvm.service_name = item.service_name;
                servicesList.Add(servicessvm);
            }

            return servicesList;
        }
        public void AddServices(servicesVM _servicesVM)
        {
            service serviceToAdd = new service();
            serviceToAdd.service_id = _servicesVM.service_id;
            serviceToAdd.service_name = _servicesVM.service_name;
            MCDB.services.Add(serviceToAdd);
            MCDB.SaveChanges();
        }
        public servicesVM getServiceById(int id)
        {
            service serviceToGet = MCDB.services.Where(x => x.service_id == id).FirstOrDefault();
            servicesVM _serviceVM = new servicesVM();
            if (serviceToGet != null)
            {
                _serviceVM.service_id = serviceToGet.service_id;
                _serviceVM.service_name = serviceToGet.service_name;
                return _serviceVM;
            }
            else
            {
                return null;
            }
        }
        public void UpdateNewsTypes(servicesVM services)
        {
            service serviceToUpdate = MCDB.services.FirstOrDefault(x => x.service_id == services.service_id);
            serviceToUpdate.service_id = services.service_id;
            serviceToUpdate.service_name = services.service_name;
            MCDB.SaveChanges();

        }
        public void DeleteServices(int id)
        {

            DeleteCourses(id);
            service serviceToDelete = MCDB.services.Where(x => x.service_id == id).FirstOrDefault();
            MCDB.services.Remove(serviceToDelete);
            MCDB.SaveChanges();
        }
        public void DeleteCourses(int id)
        {
            List<course> coursesToDelete = MCDB.courses.Where(x => x.course_id == id).ToList();
            foreach (var item in coursesToDelete)
            {
                MCDB.courses.Remove(item);
                MCDB.SaveChanges();
            }
        }

        // function user 

        public List<servicesVM> gettopservice()
        {
            List<servicesVM> mylist = new List<servicesVM>();
            List<service> topservice = MCDB.services.OrderBy(a => a.service_id).Take(3).ToList();
            foreach (var item in topservice)
            {
                servicesVM serviceobj = new servicesVM();
                serviceobj.service_id = item.service_id;
                serviceobj.service_name = item.service_name;

                mylist.Add(serviceobj);
            }
            return mylist;
        }
    }
}
