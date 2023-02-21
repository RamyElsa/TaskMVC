using ApptaskData.Repositories;
using ApptaskData.Static;
using ApptaskData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Threading.Tasks;

namespace AppTaskMVC.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TaskMVCController : Controller
    {
        private readonly ITaskMVCRepository _TAsk;

        public TaskMVCController(ITaskMVCRepository tAsk)
        {
            _TAsk = tAsk;
        }


        public async Task<IActionResult> TaskList()
        {
            var AllTask = await _TAsk.GetAllAsync();
            return View(AllTask);
        } 

        public IActionResult Delete(int id)
        {
            var result = _TAsk.Delete(id);
            return RedirectToAction(nameof(TaskList));
        } // Done Code 

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var TaskDrop = await _TAsk.GetNewTaskDropdowns();
            ViewBag.Students = new SelectList(TaskDrop.TaskStudents, "Id", "Name");
            return View();
        } // Done Code 

        [HttpPost]
        public async Task<IActionResult> Create(NewTaskVM task)
        {
            if(ModelState.IsValid)
            {
                var TaskDrop = await _TAsk.GetNewTaskDropdowns();
                ViewBag.Students = new SelectList(TaskDrop.TaskStudents, "Id", "Name");
                return View(task);
            }
            await _TAsk.AddNewTaskAsync(task);
            return RedirectToAction(nameof(Create));
        } // Done Code 


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            var data = await _TAsk.GetTaskByIdAsync(id);
            if (data == null) return View("NotFound");
            
                var response = new NewTaskVM()
                {
                    Id = data.Id,
                    Description = data.Description,
                    TeacherName = data.TeacherName,
                    Period = data.Period,
                    StudentId = data.StudentId,

                };

            var TaskDrop = await _TAsk.GetNewTaskDropdowns();
            ViewBag.Students = new SelectList(TaskDrop.TaskStudents, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewTaskVM vM)
        {

            if (id != vM.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                var TaskDrop = await _TAsk.GetNewTaskDropdowns();
                ViewBag.Students = new SelectList(TaskDrop.TaskStudents, "Id", "Name");
                return View(vM);
            }

            await _TAsk.UpdateTaskAsync(vM);
            return RedirectToAction(nameof(TaskList));


        }














    }
}
