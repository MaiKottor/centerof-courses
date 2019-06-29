using FinalProject.BLL.ViewModels;
using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.BusinessLayer
{
   public class newsBLL
    {
        MCenterDBContext MCDB = new MCenterDBContext();

        //adding a course
        public void AddNews(newsVM _newsVM)
        {
            news newsToAdd = new news();
            newsToAdd.news_id = _newsVM.news_id;
            newsToAdd.Title = _newsVM.Title;
            newsToAdd.description = _newsVM.description;
            newsToAdd.date = _newsVM.date;
            newsToAdd.image = _newsVM.image;


            newsToAdd.type_id = _newsVM.type_id;
            
            MCDB.news.Add(newsToAdd);
            MCDB.SaveChanges();
        }

        //getting news
        public  List<newsVM> getAllNews()
        {

            List<newsVM> newslist = new List<newsVM>();

            List<news> newsesFromDB = MCDB.news.ToList();
            foreach (var item in newsesFromDB)
            {
                newsVM newsvm = new newsVM();
                newsvm.news_id = item.news_id;
                newsvm.Title = item.Title;
                newsvm.date = item.date;
                newsvm.description = item.description;
                newsvm.image = item.image;
                newsvm.type_id = item.type_id;
                newsvm.type_name = item.news_type.type_name;

                newslist.Add(newsvm);
            }
            return newslist;

        }

        public newsVM getNewsById(int id)
        {
            news newsToGet = MCDB.news.Where(x => x.news_id == id).FirstOrDefault();
            newsVM _newsVM = new newsVM();
            if (newsToGet != null)
            {
                _newsVM.news_id = newsToGet.news_id;
                _newsVM.Title = newsToGet.Title;
                _newsVM.description = newsToGet.description;
                _newsVM.date = newsToGet.date;
                _newsVM.image = newsToGet.image;
                _newsVM.type_id = newsToGet.type_id;
                return _newsVM;
            }
            else
            {
                return null;
            }
        }


        //updating news
        public void UpdateNews(newsVM news)
        {
            news newsToUpdate = MCDB.news.FirstOrDefault(x => x.news_id == news.news_id);
            //MCDB.Entry(courseToDelete).State = System.Data.Entity.EntityState.Modified;
            newsToUpdate.news_id = news.news_id;
            newsToUpdate.Title = news.Title;
            newsToUpdate.date = news.date;
            newsToUpdate.description = news.description;
            if (news.image != null)
            {
                newsToUpdate.image = news.image;
            }
            newsToUpdate.type_id = news.type_id;
            MCDB.SaveChanges();

        }

        //delete news
        public void DeleteNews(int id)
        {
            news newsToDelete = MCDB.news.Where(x => x.news_id == id).FirstOrDefault();
            MCDB.news.Remove(newsToDelete);
            MCDB.SaveChanges();
        }


        // User Function 
        public List<newsVM> gettopnews()
        {
           List<newsVM> nVM = new List<newsVM>();
           List<news> newstop = MCDB.news.OrderBy(a=>a.news_id).Take(3).ToList();
            foreach (var item in newstop)
            {
                newsVM newsobj = new newsVM();
                newsobj.news_id = item.news_id;
                newsobj.description = item.description;
                newsobj.date = item.date;
                newsobj.image = item.image;
                newsobj.type_id = item.type_id;
                newsobj.type_name = item.news_type.type_name;
                nVM.Add(newsobj);
            }
            return nVM;

        }

    }
}
