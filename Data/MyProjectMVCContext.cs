using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProjectMVC.Models;

namespace MyProjectMVC.Data
{
    public class MyProjectMVCContext : DbContext
    {
        public MyProjectMVCContext (DbContextOptions<MyProjectMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
