namespace FinalProject.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("course")]
    public partial class course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course()
        {
            attendances = new HashSet<attendance>();
            user_course = new HashSet<user_course>();
        }

        [Key]
        public int course_id { get; set; }

        public int service_id { get; set; }

        public int category_id { get; set; }

        public int? instructor_id { get; set; }

        [StringLength(50)]
        public string course_name { get; set; }

        public double? price { get; set; }

        [StringLength(50)]
        public string starting_date { get; set; }

        [StringLength(50)]
        public string appointments { get; set; }

        public string description { get; set; }

        public bool? isActive { get; set; }

        public int? hours_number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendance> attendances { get; set; }

        public virtual courses_category courses_category { get; set; }

        public virtual instructor instructor { get; set; }

        public virtual service service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_course> user_course { get; set; }
    }
}
