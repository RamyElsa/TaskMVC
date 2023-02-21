
using AppTaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.ViewModels
{
    public class NewTaskDropdownVM
    {
        public NewTaskDropdownVM() 
        {
            TaskStudents = new List<TaskStudents>();
        }

        public List <TaskStudents> TaskStudents { get; set; }
    }
}
