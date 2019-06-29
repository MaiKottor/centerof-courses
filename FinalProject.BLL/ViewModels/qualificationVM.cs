using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class qualificationVM
    {
        public int qualification_id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        public string qualification_name { get; set; }

        public DateTime? qualification_date { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        public string organization { get; set; }

    }
}
