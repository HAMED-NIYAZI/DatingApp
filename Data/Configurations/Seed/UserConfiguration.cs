using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace Data.Configurations.Seed
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Email = "sth@gamil.com", UserName = "sth", Password = "sth" },
                new User { Id = 2, Email = "Yahoo@gamil.com", UserName = "Yahoo", Password = "Yahoo" },
                new User { Id = 3, Email = "admin@gamil.com", UserName = "admin", Password = "admin" }
                );
        }
    }

}
