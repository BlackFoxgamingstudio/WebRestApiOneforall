using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class StoryboardContext : DbContext
    {
        public StoryboardContext(DbContextOptions<StoryboardContext> options) : base(options)
        {

        }

        public DbSet<StoryboardDetail> StoryboardDetails { get; set; }

    }
}
