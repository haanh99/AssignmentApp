using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentApp.Data;
using AssignmentApp.Models;
using Microsoft.AspNetCore.Hosting;

namespace AssignmentApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoursesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = _context.Courses;
                
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //public async Task<IActionResult> Create(Courses courseM)
        //{
        //    var course = new Courses
        //    {
        //        Name = courseM.Name,
        //        StartTime = courseM.StartTime,
        //        EndTime = courseM.EndTime,
        //    };
        //    await _context.Courses.AddAsync(course);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Courses");
        //}
        
        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,EndTime")] Courses course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        //[HttpPost]
        
        //public async Task<IActionResult> Edit(int id, Courses course, IFormFile imageFile)
        //{
        //    if (id != course.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var existingCourse = await _context.Courses.FindAsync(id);

        //        if (existingCourse == null)
        //        {
        //            return NotFound();
        //        }

        //        existingCourse.Name = course.Name;
        //        existingCourse.StartTime = course.StartTime;
        //        existingCourse.EndTime = course.EndTime;

        //        if (imageFile != null )
        //        {
        //            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await imageFile.CopyToAsync(fileStream);
        //            }

        //            // Delete the previous image file
        //            if (!string.IsNullOrEmpty(existingCourse.ImageFile))
        //            {
        //                string previousFilePath = Path.Combine(uploadsFolder, existingCourse.ImageFile);
        //                if (System.IO.File.Exists(previousFilePath))
        //                {
        //                    System.IO.File.Delete(previousFilePath);
        //                }
        //            }

        //            existingCourse.ImageFile = uniqueFileName;
        //        }

        //        _context.Update(existingCourse);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(course);
        //}
        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);
        //    if (course != null)
        //    {
        //        _context.Courses.Remove(course);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                // Delete the associated image file
                if (!string.IsNullOrEmpty(course.ImageFile))
                {
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", course.ImageFile);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
