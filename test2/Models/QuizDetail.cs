using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuizDetail
    {
        [Key]
        public int QId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Question { get; set; }
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
        public string choices1 { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string choices2 { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string choices3 { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string choices4 { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string choices5 { get; set; }
        [Required]
        [Column(TypeName = "varchar(8000)")]
        public string Sourcename { get; set; }

    }
}
