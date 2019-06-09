using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class KeyWordContext : DbContext
    {
        public KeyWordContext(DbContextOptions<KeyWordContext> options) : base(options)
        {

        }

        public DbSet<KeyWordDetail> KeyWordDetails { get; set; }

    }
}
