using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
   public class newsTypeBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();
        //get all newsTypes
        public List<newsTypeVM> getAllnewsTypes()
        {
            List<newsTypeVM> newsTypes = new List<newsTypeVM>();
            var types = MCDB.news_type.ToList();
            foreach (var item in types)
            {
                newsTypeVM typesvm = new newsTypeVM();
                typesvm.type_id = item.type_id;
                typesvm.type_name = item.type_name;
                newsTypes.Add(typesvm);
            }

            return newsTypes;
        }



        public void AddNewsType(newsTypeVM _newsTypeVM)
        {
            news_type newsTypeToAdd = new news_type();
            newsTypeToAdd.type_id = _newsTypeVM.type_id;
            newsTypeToAdd.type_name = _newsTypeVM.type_name;
            MCDB.news_type.Add(newsTypeToAdd);
            MCDB.SaveChanges();
        }
     





        public newsTypeVM getNewsTypeById(int id)
        {
            news_type newsTypeToGet = MCDB.news_type.Where(x => x.type_id == id).FirstOrDefault();
            newsTypeVM _newsTypeVM = new newsTypeVM();
            if (newsTypeToGet != null)
            {
                _newsTypeVM.type_id = newsTypeToGet.type_id;
                _newsTypeVM.type_name = newsTypeToGet.type_name;
                return _newsTypeVM;
            }
            else
            {
                return null;
            }
        }
        public void UpdateNewsTypes(newsTypeVM newsTypes)
        {
            news_type newsToUpdate = MCDB.news_type.FirstOrDefault(x => x.type_id == newsTypes.type_id);
            newsToUpdate.type_id = newsTypes.type_id;
            newsToUpdate.type_name = newsTypes.type_name;
            MCDB.SaveChanges();

        }
        public void DeleteNewsType(int id)
        {

            DeleteNews(id);
            news_type newsTypesToDelete = MCDB.news_type.Where(x => x.type_id == id).FirstOrDefault();
            MCDB.news_type.Remove(newsTypesToDelete);
            MCDB.SaveChanges();
        }
        public void DeleteNews(int id)
        {
            List<news> newsToDelete = MCDB.news.Where(x => x.news_id == id).ToList();
            foreach (var item in newsToDelete)
            {
                MCDB.news.Remove(item);
                MCDB.SaveChanges();
            }
        }
    }
}
