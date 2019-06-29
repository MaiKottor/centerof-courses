namespace FinalProject.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lab")]
    public partial class lab
    {
        [Key]
        public int lab_id { get; set; }

        public int service_id { get; set; }

        public int? lab_number { get; set; }

        [StringLength(50)]
        public string lab_name { get; set; }

        public int? floor_number { get; set; }

        public string description { get; set; }

        public virtual service service { get; set; }
    }
}
