using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CodeContext : DbContext
    {
        public CodeContext(DbContextOptions<CodeContext> options) : base(options)
        {

        }

        public DbSet<CodeDetail> CodeDetails { get; set; }

    }
}
