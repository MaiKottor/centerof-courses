using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
    public class CourseVM
    {
        [Key]
        public int course_id { get; set; }

        public int service_id { get; set; }

        public int category_id { get; set; }

        public int? instructor_id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50, ErrorMessage ="لا يمكن ادخال اكثر من 50 حرف")]
        public string course_name { get; set; }

        [Required(ErrorMessage = "*")]
        public double? price { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string starting_date { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string appointments { get; set; }

        [Required(ErrorMessage = "*")]
        public string description { get; set; }

        [Required(ErrorMessage = "*")]
        public bool? isActive { get; set; }

        [Required(ErrorMessage = "*")]
        public int? hours_number { get; set; }


        public virtual courses_category courses_category { get; set; }

        public virtual service service { get; set; }

        public virtual instructor instructor { get; set; }

    }
}
