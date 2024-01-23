using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_Approach_of_Entity_Framework.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Gender { get; set; }
        public int Age { get; set; }
    }
}