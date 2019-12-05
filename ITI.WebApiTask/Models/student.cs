using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ITI.WebApiTask.Models
{
    public class student { 
    
        [Key]
        public int student_id { get; set; }
        [Required]
        public string student_Name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        //foreign key
        public int emp_Id { get; set; }
        public Department employee { get; set; }
    }
}