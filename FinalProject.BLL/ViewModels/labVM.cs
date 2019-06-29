using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
    public class labVM
    {
        public int lab_id { get; set; }

        public int service_id { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب اداخال ارقام فقط")]
        public int? lab_number { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 حرف")]
        public string lab_name { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب اداخال ارقام فقط")]
        public int? floor_number { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 حرف")]
        public string description { get; set; }

    }
}
