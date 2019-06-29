using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BLL.ViewModels;
using FinalProject.DAL;

namespace FinalProject.BLL.BusinessLayer
{
  public  class UsersBll
    {
        MCenterDBContext MCDB = new MCenterDBContext();
        public  List<UsersVM> getAllUsers()
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {

                List<UsersVM> lstUsers = db.user_data.Select(x =>
                new UsersVM
                {
                    user_name = x.user_name,
                    address = x.address,
                    age = x.age,
                    email = x.email,
                    national_id = x.national_id.ToString(),
                    role = x.role,
                    user_id = x.user_id,
                    phone = x.phone,
                    qualification_name = x.qualification.qualification_name,
                    loginUserName=x.loginUserName,
                    password=x.password,
                    qualification_id=x.qualification_id
                    
                }).ToList();
                return lstUsers;
            }

        }

        public bool isValidUser(string email, string userName)
        {
            user_data user = MCDB.user_data.FirstOrDefault(x => x.email == email && x.user_name == userName);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  bool AddUser(UsersVM userVM)
        {
            if (isValidUser(userVM.email, userVM.user_name))
            {

                user_data userToAdd = new user_data();
                userToAdd.user_name = userVM.user_name;
                userToAdd.address= userVM.address;
                userToAdd.age= userVM.age;
                userToAdd.email= userVM.email;
                userToAdd.national_id = userVM.national_id;
                userToAdd.phone= userVM.phone;
                userToAdd.role= userVM.role;
                userToAdd.qualification_id= userVM.qualification_id;
                userToAdd.loginUserName = userVM.loginUserName;
                userToAdd.password = userVM.password;
                userToAdd.qualification_id = userVM.qualification_id;

                MCDB.user_data.Add(userToAdd);
                MCDB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public  void UpdateUser(UsersVM userVm)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                user_data updataedUser = getUserByID(userVm.user_id);
                updataedUser.user_name = userVm.user_name;
                updataedUser.age = userVm.age;
                updataedUser.email = userVm.email;
                updataedUser.national_id = userVm.national_id;
                updataedUser.address = userVm.address;
                updataedUser.phone = userVm.phone;
                updataedUser.qualification_id = userVm.qualification_id;
                updataedUser.loginUserName = userVm.loginUserName;
                updataedUser.password = userVm.password;

                db.Entry(updataedUser).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public  void DeleteUser(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                user_data deletedIns = getUserByID(id);
                //  db.instructors.Remove(deletedIns);
                db.Entry(deletedIns).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }
        public   user_data getUserByID(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                user_data user = db.user_data.Where(x => x.user_id == id).SingleOrDefault();
                return user;
            }
        }

        public  UsersVM getUserByID2(int id)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                UsersVM user = db.user_data.Where(x => x.user_id == id).Select(x =>
                        new UsersVM
                        {
                            user_id = x.user_id,
                            user_name = x.user_name,
                            address = x.address,
                            age = x.age,
                            email = x.email,
                            national_id = x.national_id.ToString(),
                            phone = x.phone,
                            qualification_id = x.qualification.qualification_id,
                            role = x.role
                        }).SingleOrDefault();
                return user;
            }
        }


        public   UsersVM getUserBYName(string loginName)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                UsersVM user = db.user_data.Where(x => x.loginUserName == loginName).Select(x =>
                        new UsersVM
                        {
                            user_name = x.user_name,
                            address = x.address,
                            age = x.age,
                            email = x.email,
                            national_id = x.national_id.ToString(),
                            phone = x.phone,
                            qualification_id = x.qualification.qualification_id,
                            role = x.role
                        }).SingleOrDefault();
                return user;
            }
        }

        public UsersVM checkUserLogin(LoginVM login)
        {
            using (MCenterDBContext db = new MCenterDBContext())
            {
                UsersVM user = db.user_data.Where(x => x.user_name == login.user_name && x.password==login.password).Select(x =>
                        new UsersVM
                        {
                            user_name = x.user_name,
                            user_id = x.user_id,
                            address = x.address,
                            age = x.age,
                            email = x.email,
                            national_id = x.national_id.ToString(),
                            phone = x.phone,
                            qualification_id = x.qualification.qualification_id,
                            role = x.role
                        }).SingleOrDefault();
                return user;
            }
        }

    }
}
