using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StayFitGym.Model
{
    public class ApplicationDbContext: DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<Membership> Membership { get; set; }
    }
}
