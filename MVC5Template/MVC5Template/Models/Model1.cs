namespace MVC5Template.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MVC5TemplateServerModel")
        {
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FamilyName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Prefectures)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Apartment)
                .IsUnicode(false);
        }
    }
}
