
using ApptaskData.Repositories;
using AppTaskModels;
using AppTaskModels.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.ViewModels
{
    public class NewTaskVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Period")]
        [Required]
        public int Period { get; set; }

        [Display(Name = "Teacher Name")]
        [Required]
        public string TeacherName { get; set; }

        [Display(Name = "Select a Status")]
        [Required]
        public string status { get; set; }

        [Display(Name = "Select a Student")]
        [Required]
        public int StudentId { get; set; }

        public string StudentName { get; set; }
    }
}
