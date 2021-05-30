using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Models
{
    public class Student
    {
        [Key]
        public int Roll_Number { get; set; }

        public string Name { get; set; }

        public int Class { get; set; }

    }
}
