using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class WorkflowContext : DbContext
    {
        public WorkflowContext(DbContextOptions<WorkflowContext> options) : base(options)
        {

        }

        public DbSet<WorkflowDetail> WorkflowDetails { get; set; }

    }
}
