using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCAvansys.DataLayer;
using MVCAvansysWebApp.Models;

namespace MVCAvansysWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCAvansysContext _context;

        public StudentsController(MVCAvansysContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.Include("Career").ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include("Career").FirstOrDefaultAsync(_ => _.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentModel = new StudentModel()
            {
                ID = student.ID,
                CareerID = student.CareerID.ToString(),
                Name = student.Name,
                CareerName = student.Career.Name
            };

            return View(studentModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            var careers = _context.Career.ToList();
            ViewData["Careers"] = careers.Select(_ => new SelectListItem
            {
                Text = _.Name,
                Value = _.ID.ToString()
            });
            return View( );
        }



        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( StudentModel student)
        {

            if (ModelState.IsValid)
            {
                var studentTable = new Student()
                {
                    ID = student.ID,
                    Name = student.Name,
                    CareerID = Guid.Parse(student.CareerID)
                };

                studentTable.ID = Guid.NewGuid();
                _context.Add(studentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include("Career").FirstOrDefaultAsync(_ => _.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            var careers = _context.Career.ToList();
            ViewData["Careers"] = careers.Select(_ => new SelectListItem
            {
                Text = _.Name,
                Value = _.ID.ToString()
            });

            var studentModel = new StudentModel()
            {
                ID = student.ID,
                CareerID = student.CareerID.ToString(),
                Name = student.Name
            };

            return View(studentModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StudentModel student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var studentTable = new Student()
                {
                    ID = student.ID,
                    Name = student.Name,
                    CareerID = Guid.Parse(student.CareerID)
                };
                try
                {
                    _context.Update(studentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentTable.ID))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(Guid id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
