using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.WebApiTask.Models
{
    public class StudentDetailDTO
    {
        public int student_id{ get; set; }
        public string dept_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }
}