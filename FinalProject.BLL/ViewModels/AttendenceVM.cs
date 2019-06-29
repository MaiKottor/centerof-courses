using FinalProject.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.ViewModels
{
    public class AttendenceVM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime date { get; set; }

        public int course_id { get; set; }

        public bool? attendant { get; set; }

        public DateTime? attendant_time { get; set; }

        public bool? departure { get; set; }

        public DateTime? departure_time { get; set; }

        public virtual course course { get; set; }

        public virtual user_data user_data { get; set; }
        //custum attribute

        public string courseName { get; set; }
        public string UserName { get; set; }
    }
}
