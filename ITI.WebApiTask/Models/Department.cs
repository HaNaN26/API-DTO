using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ITI.WebApiTask.Models
{
    public class Department
    {
        [Key]
        public int dept_id { get; set; }
        [Required]
        public string dept_name { get; set; }
    }
}