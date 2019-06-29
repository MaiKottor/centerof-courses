using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class newsTypeVM
    {
        public int type_id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50, ErrorMessage ="لا يمكن ادخال اكثر من 50 حرف")]
        public string type_name { get; set; }
        public virtual List<news> news { get; set; }
    }
}
