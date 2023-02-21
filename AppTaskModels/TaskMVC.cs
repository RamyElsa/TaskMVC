using AppTaskModels.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaskModels
{
    public class TaskMVC
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Period { get; set; }
        public string TeacherName { get; set; }
        public string ChosesStatus { get; set; } 


        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public TaskStudents Students { get; set; }

    }
}
