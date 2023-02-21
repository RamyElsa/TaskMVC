using AppTaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.Repositories
{
    public interface IStudentRepository
    {
        bool Add(TaskStudents students);
        bool Update(TaskStudents students);
        bool Delete(int id);
        TaskStudents GetById(int id);
        IQueryable<TaskStudents> List();
    }
}
