using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class parenterVM
    {
        [Key]
        public int parenter_id { get; set; }

        [Required(ErrorMessage = "*")]
        public string parenter_name { get; set; }

        [Required(ErrorMessage = "*")]
        public string image { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        [EmailAddress(ErrorMessage = "يجب ادخال صيغة بريد الكترونى صحيحة")]
        public string email { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب اداخال ارقام فقط")]
        [StringLength(20, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        public string phone { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب ادخال ارقام فقط")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        public string Mobile { get; set; }
    }
}
