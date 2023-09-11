using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrinceOfPeace.Models.DTO;

namespace PrinceOfPeace.Models.Domain
{
	public class DatabaseContext : IdentityDbContext<ApplicationUser>
	{
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        // Tables in database
        public DbSet<Honorifics> Honorifics { get; set; }

        public DbSet<Occupations> Occupations { get; set; }

        public DbSet<Positions> Positions { get; set; }

        public DbSet<ServiceTypes> ServiceTypes { get; set; }

        public DbSet<ChurchMember> ChurchMembers { get; set; }

        public DbSet<ImageEntity> Images { get; set; }
    }
}

