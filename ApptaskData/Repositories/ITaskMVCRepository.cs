using ApptaskData.ViewModels;
using AppTaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.Repositories
{
    public interface ITaskMVCRepository
    {
        bool Delete(int id);
        Task<TaskMVC> GetTaskByIdAsync(int id);
        Task<NewTaskDropdownVM> GetNewTaskDropdowns();
        Task AddNewTaskAsync(NewTaskVM data);
        Task UpdateTaskAsync(NewTaskVM data);
        Task<IEnumerable<TaskMVC>> GetAllAsync();

       // NewTaskVM List();
        Task UpdateStatusAsync(NewTaskVM data);


        // Test Code
        //bool Add(NewTaskVM data);
        //bool GetNewTaskDropdowns(NewTaskDropdownVM vM);
        //bool Update(NewTaskVM data);
        //bool Delete(int id);
        //TaskMVC GetById(int id);
        //IQueryable<TaskMVC> List();
    }
}
