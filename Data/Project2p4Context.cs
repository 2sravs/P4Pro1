using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2p4.Models;

namespace Project2p4.Data
{
    public class Project2p4Context : DbContext
    {
        public Project2p4Context (DbContextOptions<Project2p4Context> options)
            : base(options)
        {
        }

        public DbSet<Project2p4.Models.user> user { get; set; } = default!;

        public DbSet<Project2p4.Models.Custlog>? Custlog { get; set; }
    }
}
