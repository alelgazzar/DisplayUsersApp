using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DisplayUsersApp.Models;

namespace DisplayUsersApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
