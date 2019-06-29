using FinalProject.MyValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class LoginVM
    {
       [Required(ErrorMessage = "يجب ادخال كلمة المرور")]
       [PasswordValidation(ErrorMessage = "password must conntain lower ,upper ,digit ,number and special character")]
        public string password { get; set; }
       [Required(ErrorMessage = "يجي ادخال اسم المستخدم")]
        public string user_name { get; set; }
    }
}
