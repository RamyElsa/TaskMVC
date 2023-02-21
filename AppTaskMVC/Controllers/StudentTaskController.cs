using ApptaskData.Repositories;
using ApptaskData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppTaskMVC.Controllers
{
    public class StudentTaskController : Controller
    {
        private readonly ITaskMVCRepository _TAsk;

        public StudentTaskController(ITaskMVCRepository tAsk)
        {
            _TAsk = tAsk;
        }

        public async Task<IActionResult> Index()
        {
            var AllTask = await _TAsk.GetAllAsync();
            return View(AllTask);
        }


        [HttpGet]
        public async Task<IActionResult> StudentEdit(int id)
        {
            var data = await _TAsk.GetTaskByIdAsync(id);
            if (data == null) { return View("NotFound"); }
            var response = new NewTaskVM()
            {
                Description = data.Description,
                TeacherName = data.TeacherName,
                Period = data.Period,
                StudentId = data.StudentId,

            };
            var tas = await _TAsk.GetNewTaskDropdowns();
            ViewBag.Students = new SelectList(tas.TaskStudents, "Id", "Name");
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> StudentEdit(int id, NewTaskVM vM)
        {
            if (id != vM.Id) return View("NotFound");

            if (ModelState.IsValid)
            {
                return View(vM);
            }

            await _TAsk.UpdateStatusAsync(vM);
            return RedirectToAction(nameof(Index));
        }
    }
}
