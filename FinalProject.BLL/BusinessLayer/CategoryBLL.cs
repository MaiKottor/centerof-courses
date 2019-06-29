using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
    public class CategoryBLL
    {
        MCenterDBContext mcdb = new MCenterDBContext();
        public List<CategoryVM> getAllCategs()
        {
            List<CategoryVM> categs = new List<CategoryVM>();
            var categ = mcdb.courses_category.ToList();

            foreach (var item in categ)
            {
                CategoryVM cmv = new CategoryVM();
                cmv.category_id = item.category_id;
                cmv.category_name = item.category_name;
                categs.Add(cmv);
            }

            return categs;
        }





        public void AddCategory(CategoryVM _catsVM)
        {
            courses_category categoryToAdd = new courses_category();
            categoryToAdd.category_id = _catsVM.category_id;
            categoryToAdd.category_name = _catsVM.category_name;
            mcdb.courses_category.Add(categoryToAdd);
            mcdb.SaveChanges();
        }





        public CategoryVM getCategById(int id)
        {
            courses_category catsToGet = mcdb.courses_category.Where(x => x.category_id == id).FirstOrDefault();
            CategoryVM _catsVM = new CategoryVM();
            if (catsToGet != null)
            {
                _catsVM.category_id = catsToGet.category_id;
                _catsVM.category_name = catsToGet.category_name;
                return _catsVM;
            }
            else
            {
                return null;
            }
        }
        public void UpdateCatgs(CategoryVM categs)
        {
            courses_category catgsToUpdate = mcdb.courses_category.FirstOrDefault(x => x.category_id == categs.category_id);
            catgsToUpdate.category_id = categs.category_id;
            catgsToUpdate.category_name = categs.category_name;
            mcdb.SaveChanges();

        }
        public void DeleteCatgs(int id)
        {

            DeleteCourse(id);
            courses_category categsToDelete = mcdb.courses_category.Where(x => x.category_id == id).FirstOrDefault();
            mcdb.courses_category.Remove(categsToDelete);
            mcdb.SaveChanges();
        }
        public void DeleteCourse(int id)
        {
            List<course> courseToDelete = mcdb.courses.Where(x => x.category_id == id).ToList();
            foreach(var item in courseToDelete)
            {
                mcdb.courses.Remove(item);
                mcdb.SaveChanges();
            }
        }

    }
}
