using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dockerize.Models;

namespace Dockerize.Data
{
    public class DockerizeContext : DbContext
    {
        public DockerizeContext (DbContextOptions<DockerizeContext> options)
            : base(options)
        {
        }

        public DbSet<Dockerize.Models.Movie> Movie { get; set; } = default!;
    }
}
