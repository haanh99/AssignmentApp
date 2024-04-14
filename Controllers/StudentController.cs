using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentApp.Data;
using AssignmentApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AssignmentApp.Controllers
{
    [Authorize (Roles = "Student,Admin")]
    
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentEntity model)
        {
             var student = new StudentEntity
                {
                    Name = model.Name,
                    Age = model.Age,
                    Majo = model.Majo,
                };
                await _context.Student.AddAsync(student);
                await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Student");
        }
      
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var students = from StudentEntity in _context.Student
                           select StudentEntity;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString)
                                       || s.Majo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                
                default:
                    students = students.OrderBy(s => s.Id);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<StudentEntity>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Student/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            return View(studentEntity);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _context.Student.FindAsync(id);
            if (studentEntity == null)
            {
               return NotFound();
           }
            return View(studentEntity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentEntity student)
        {
            var Stu = await _context.Student.FindAsync(student.Id);
            if (Stu is not null)
            {
                Stu.Name = student.Name;
                Stu.Age = student.Age;
                Stu.Majo = student.Majo;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index","Student");
        }
        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEntity = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            return View(studentEntity);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentEntity = await _context.Student.FindAsync(id);
            if (studentEntity != null)
            {
                _context.Student.Remove(studentEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEntityExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
