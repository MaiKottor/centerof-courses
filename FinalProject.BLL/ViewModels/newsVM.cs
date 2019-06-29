using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
   public class newsVM
    {
        public int news_id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage ="لا يمكن ادخال اكثر من 50 حرف")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "لا يمكن ادخال اكثر من 50 حرف")]
        public string image { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage ="لا يمكن ادخال اكثر من 50 حرف")]
        public string date { get; set; }

      
        public string description { get; set; }

        public int type_id { get; set; }
        public string type_name { get; set; }

        public virtual news_type news_type { get; set; }

    }
}
