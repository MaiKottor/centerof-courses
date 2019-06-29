namespace FinalProject.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [Key]
        public int news_id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string image { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        public string description { get; set; }

        public int type_id { get; set; }

        public virtual news_type news_type { get; set; }
    }
}
