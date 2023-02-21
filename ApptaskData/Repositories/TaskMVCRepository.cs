using ApptaskData.Data;
using ApptaskData.ViewModels;
using AppTaskModels;
using AppTaskModels.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.Repositories
{
    public class TaskMVCRepository : ITaskMVCRepository
    {
        private readonly AppDbContext _context;

        public TaskMVCRepository(AppDbContext context)
        {
            _context = context;
        }

        

        public bool Delete(int id)// Done Code
        {
            try
            {
                var data = _context.Tasks.FirstOrDefault(n=>n.Id==id);
                _context.Tasks.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }




        }


        public  async Task<IEnumerable<TaskMVC>> GetAllAsync()=> await _context.Tasks.ToListAsync();
        //{
        //   _context.Tasks
        //        .Join(_context.Students,
        //        nametask => nametask.StudentId,
        //        namestudent => namestudent.Id,
        //        (nametask, namestudent) => new
        //        {

        //            StudentName = namestudent.Name,

        //        }
        //        ).ToList();
           
        //}  

        public async Task<NewTaskDropdownVM> GetNewTaskDropdowns()
        {
            var response = new NewTaskDropdownVM()
            {
                TaskStudents = await _context.Students.OrderBy(n=>n.Name).ToListAsync(), 
            };
            return response;
        }

        public async Task<TaskMVC> GetTaskByIdAsync(int id)
        {
           var taskDet =  await _context.Tasks
                .Include(c=>c.Students).FirstOrDefaultAsync(n=>n.Id==id);
            return taskDet;
        }

        public async Task AddNewTaskAsync(NewTaskVM data) // Done Code
        {
            var newTask = new TaskMVC()
            {
                Description = data.Description,
                Period = data.Period,
                Date = DateTime.UtcNow,
                TeacherName = data.TeacherName,
                ChosesStatus = ChosesStatus.Pending.ToString(),
                StudentId = data.StudentId,
            };
            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();
        }

        public async  Task UpdateTaskAsync(NewTaskVM data)
        {
            var db = await _context.Tasks.FirstOrDefaultAsync(n=>n.Id==data.Id);

            if (db != null)
            {
                
                db.Description = data.Description;
                db.Period = data.Period;
                db.TeacherName = data.TeacherName;
                db.StudentId = data.StudentId;
               // db.ChosesStatus = data.status;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
           
        }

        public async Task UpdateStatusAsync(NewTaskVM data)
        {
            var db = await _context.Tasks.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if (db != null)
            {
                int x = int.Parse(data.status);
                ChosesStatus da = (ChosesStatus) x ;
                db.ChosesStatus = da.ToString();

                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

  

        //public List<NewTaskVM> GetAllTasks()
        //{
        //    var List = _context.Students.ToList();

        //    var names = _context.Tasks
        //        .Join(_context.Students,
        //        nametask => nametask.StudentId,
        //        namestudent => namestudent.Id,
        //        (nametask, namestudent) => new
        //        {

        //            StudentName = namestudent.Name,

        //        }
        //        ).ToList();
        //    foreach (var name in names)
        //    {
        //        return name.StudentName;
        //    }

        //    /*
        //    List<TaskStudents> students = _context.Students.ToList();
        //    List<TaskMVC> tasks = _context.Tasks.ToList();
        //    var TaskRecord = from e in students
        //                     join d in tasks on e.Id equals d.StudentId into table1
        //                     from d in table1.ToList()
        //                     select new NewTaskVM
        //                     {
        //                         StudentName = e.Name,
        //                         Description = d.Description,
        //                         TeacherName = d.TeacherName,
        //                         Period = d.Period,
        //                         Date = d.Date,
        //                         status = d.ChosesStatus

        //                     };

        //    return TaskRecord;
        //    */


        //}
    }
}
