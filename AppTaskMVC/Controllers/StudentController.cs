using ApptaskData.Repositories;
using ApptaskData.Static;
using AppTaskModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace AppTaskMVC.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class StudentController : Controller
    {
       

        private readonly IStudentRepository _StudentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _StudentRepo = studentRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskStudents students)
        {
            if (ModelState.IsValid)
            {
                return View(students);
            }
            var data = _StudentRepo.Add(students);
            if (data)
            {
                TempData["msg"] = "Add Successfully";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["msg"] = "Add Failed";
                return View(students);
            }
        }

        public IActionResult StudentList()
        {
            var data = _StudentRepo.List().ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var Result = _StudentRepo.Delete(id);
            return RedirectToAction(nameof(StudentList));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _StudentRepo.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(TaskStudents students)
        {
            if (ModelState.IsValid) { return View(students); }
            var data = _StudentRepo.Update(students);
            if (data)
            {
                TempData["msg"] = "Update Successfully";
                return RedirectToAction(nameof(StudentList));
            }
            else
            {
                TempData["msg"] = "Update Failed";
                return View(students);
            }
        }
    }
}
