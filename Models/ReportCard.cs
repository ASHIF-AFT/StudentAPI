using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Models
{
    public class ReportCard
    {   
        [Key]
        public int Id { get; set; }

        public int Student { get; set; }

        public int ScienceMarks { get; set; }

        public int MathsMarks { get; set; }

    }
}
