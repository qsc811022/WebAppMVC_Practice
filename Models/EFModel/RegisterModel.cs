using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAppMVC.Models.EFModel
{
    public partial class RegisterModel : DbContext
    {
        public RegisterModel()
            : base("name=RegisterModel")
        {
        }

        public virtual DbSet<GuestBook> GuestBooks { get; set; }
        public virtual DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestBook>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);
        }
    }
}
