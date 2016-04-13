using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DMProject.Entities;

namespace DMProject.Data.Infrastructure
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.id);
        }
    }

    public class UserEntityConfiguration : EntityBaseConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            Property(u => u.name).IsRequired().HasMaxLength(50);
            Property(u => u.password).HasMaxLength(2000);
            Property(u => u.salt).HasMaxLength(50);
            Property(u => u.truename).HasMaxLength(50);
            Property(u => u.sex).HasMaxLength(50);
            Property(u => u.positon).HasMaxLength(50);
            Property(u => u.position_desc).HasMaxLength(500);
            Property(u => u.office_phone).HasMaxLength(50);
            Property(u => u.mobile).HasMaxLength(50);
            Property(u => u.home_phone).HasMaxLength(50);
            Property(u => u.email).HasMaxLength(50);
            Property(u => u.address).HasMaxLength(500);
        }
    }
    public class PrivilegeConfiguration : EntityBaseConfiguration<Privilege>
    {
        public PrivilegeConfiguration()
        {
            Property(u => u.name).IsRequired().HasMaxLength(50);
            Property(u => u.code).HasMaxLength(50);
            Property(u => u.type).HasMaxLength(50);
            Property(u => u.path).HasMaxLength(250);
          
        }
    }
    public class MenuConfiguration : EntityBaseConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            Property(u => u.name).IsRequired().HasMaxLength(50);
            Property(u => u.menutype).HasMaxLength(50);
            Property(u => u.code).HasMaxLength(50);
            Property(u => u.menutype).HasMaxLength(50);
            Property(u => u.module).HasMaxLength(100);
            Property(u => u.moduleconfig).HasMaxLength(50);
            Property(u => u.method).HasMaxLength(10);
            Property(u => u.url).HasMaxLength(250);
            Property(u => u.iconcls).HasMaxLength(50);
            Property(u => u.path).HasMaxLength(250);
            Property(u => u.xtype).HasMaxLength(50);
            Property(u => u.disable).HasMaxLength(10);


        }
    }
    public class RoleDefineConfiguration : EntityBaseConfiguration<RoleDefine>
    {
        public RoleDefineConfiguration()
        {
            Property(u => u.name).IsRequired().HasMaxLength(50);
            Property(u => u.code).HasMaxLength(50);
            Property(u => u.description).HasMaxLength(500);
            Property(u => u.status).HasMaxLength(10);

        }
    }
}
