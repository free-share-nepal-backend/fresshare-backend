namespace Profile.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Dbcontext;

    public partial class Dbmodel : DbContext
    {
        public Dbmodel()
            : base("name=Dbmodel")
        {
            Database.SetInitializer<Dbmodel>(new DatabaseInitializer());
        }
        public virtual DbSet<Dbcontext.About_Me> About_Me { get; set; }
        public virtual DbSet<Dbcontext.User_Info> User_Info { get; set; }

        public virtual DbSet<Dbcontext.Client_Info> Client_Info { get; set; }
        public virtual DbSet<Dbcontext.Skill> Skill { get; set; }

        public virtual DbSet<Dbcontext.Experience> Experience { get; set; }

        public virtual DbSet<Dbcontext.Education> Education { get; set; }
        public virtual DbSet<Dbcontext.Work> Work { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
