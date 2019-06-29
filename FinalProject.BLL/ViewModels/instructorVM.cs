using FinalProject.DAL;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.BLL.ViewModels
{
  public  class instructorVM
    {
        [Key]
        public int instructor_id { get; set; }


        [Required(ErrorMessage = "*")]
        public string instructor_name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Current_JobTitle { get; set; }

        [Required(ErrorMessage = "*")]
        public string NameOf_ItsUnit { get; set; }

        [Required(ErrorMessage = "*")]
        public string TrainningTopic { get; set; }

        [Required(ErrorMessage = "*")]
        public string QualificationsName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage ="لايمكن ادخال اكثر من 50 حرف")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب اداخال ارقام فقط")]
        public string phone { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 حرف")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "يجب اداخال ارقام فقط")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 حرف")]
        [EmailAddress(ErrorMessage = "يجب ادخال صيغة بريد الكترونى صحيحة")]
        public string Email { get; set; }


    }
}
