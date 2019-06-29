namespace FinalProject.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("parenter")]
    public partial class parenter
    {
        [Key]
        public int parenter_id { get; set; }

        public string parenter_name { get; set; }

        public string image { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }
    }
}
