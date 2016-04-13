using System;
using System.Data.Entity;
using DMProject.Entities;
using DMProject.Data.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace DMProject.Data
{
    public class DMProjectContext : DbContext
    {
        public DMProjectContext() : base("DMProject")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DMProjectContext>());
        }
        public DbSet<Location> Location { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuPrivilege> MenuPrivilege { get; set; }
        public DbSet<Privilege> Privilege { get; set; }
        public DbSet<RoleDefine> RoleDefine { get; set; }
        public DbSet<RolePrivilege> RolePrivilege { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new PrivilegeConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());
        }

    }
}
