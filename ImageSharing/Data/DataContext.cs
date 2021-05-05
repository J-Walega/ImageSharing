using System;
using System.Collections.Generic;
using System.Text;
using ImageSharing.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageSharing.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
