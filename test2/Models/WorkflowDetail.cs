using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class WorkflowDetail
    {
        [Key]
        public int WFId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Workflow { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string imageurl { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string docurl { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string Sourcename { get; set; }
    }
}
