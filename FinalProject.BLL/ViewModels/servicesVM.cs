using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class servicesVM
    {
        public int service_id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لايمكن ادخال اكثر من 50 رقم")]
        public string service_name { get; set; }

    }
}
