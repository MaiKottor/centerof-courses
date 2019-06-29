namespace FinalProject.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MCenterDBContext : DbContext
    {
        public MCenterDBContext()
            : base("name=MCenterDBContext")
        {
        }

        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<courses_category> courses_category { get; set; }
        public virtual DbSet<instructor> instructors { get; set; }
        public virtual DbSet<lab> labs { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<news_type> news_type { get; set; }
        public virtual DbSet<parenter> parenters { get; set; }
        public virtual DbSet<qualification> qualifications { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<user_course> user_course { get; set; }
        public virtual DbSet<user_data> user_data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>()
                .HasMany(e => e.attendances)
                .WithRequired(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.user_course)
                .WithRequired(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<courses_category>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.courses_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.labs)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.attendances)
                .WithRequired(e => e.user_data)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_data>()
                .HasMany(e => e.user_course)
                .WithRequired(e => e.user_data)
                .WillCascadeOnDelete(false);
        }
    }
}
