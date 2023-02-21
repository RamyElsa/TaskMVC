using ApptaskData.Data;
using AppTaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptaskData.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(TaskStudents students)
        {
            try
            {
                _context.Students.Add(students);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetById(id);
                if (data == null) { return false; }
                _context.Students.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TaskStudents GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public IQueryable<TaskStudents> List()
        {
            var data = _context.Students.AsQueryable();
            return data;
        }

        public bool Update(TaskStudents students)
        {
            try
            {
                _context.Students.Update(students);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
