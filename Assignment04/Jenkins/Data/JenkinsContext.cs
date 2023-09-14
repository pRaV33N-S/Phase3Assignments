using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jenkins.Models;

namespace Jenkins.Data
{
    public class JenkinsContext : DbContext
    {
        public JenkinsContext (DbContextOptions<JenkinsContext> options)
            : base(options)
        {
        }

        public DbSet<Jenkins.Models.Movie> Movie { get; set; } = default!;
    }
}
