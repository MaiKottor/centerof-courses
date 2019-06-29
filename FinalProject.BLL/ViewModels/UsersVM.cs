using FinalProject.MyValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FinalProject.BLL.ViewModels
{
   public class UsersVM                                     
    {
        [Key]
        public int user_id { get; set; }
        [Required(ErrorMessage ="يجب ادخال السن")]

        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب ادخال قيم رقميه")]
        public int? age { get; set; }
        [Required(ErrorMessage ="يجب ادخال الاسم")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "يجب ادخال العنوان")]
        public string address { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("(2)[0-9]{13}",ErrorMessage ="يجب ان يكون 14 رقم ")]
        public string national_id { get; set; }
        [RegularExpression("(01)[0-9]{9}" , ErrorMessage="رقم غير صحيح")]
        [Required(ErrorMessage ="يجب ادخال رقم التيليفون")]
        public string phone { get; set; }
        [EmailAddress(ErrorMessage = "يجب ادخال بريدالكترونى صحيح")]
        public string email { get; set; }
        public Boolean? role { get; set; }
        public int? qualification_id { get; set; }

        //custum attribute
        public string qualification_name { get; set; }
        [Required (ErrorMessage ="يجب ادخال كلمة المرور")]
       // [PasswordValidation(ErrorMessage ="password must conntain lower ,upper ,digit ,number and special character")]
        public string password { get; set; }
        //[NotMapped]
        //[System.ComponentModel.DataAnnotations.Compare("password",ErrorMessage ="يجب تطابق كلمة المرور")]
        public string conpassword { get; set; }
        [Required(ErrorMessage ="يجي ادخال اسم المستخدم")]
        //[Remote("checkUserName","Users",ErrorMessage ="لا يمكن استخدام هذا الاسم",AdditionalFields ="user_id")]
        public string loginUserName { get; set; }

    }
}
