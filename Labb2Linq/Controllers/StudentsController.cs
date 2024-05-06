using Labb2Linq.Data;
using Labb2Linq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Controllers
{
    public class StudentsController : Controller
    {
        private readonly LinqDbContext _context;

        public StudentsController(LinqDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.SchoolClass)
                .ToListAsync();

            return View(students);
        }
        public IActionResult ListStudentsWithTeachers() // Gets all students with all of their teachers
        {
            var studentsWithTeachers = _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(c => c.Teacher)
                .ToList();

            if (studentsWithTeachers == null)
            {
                return NotFound();
            }

            return View(studentsWithTeachers);
        }

        public IActionResult StudentsWithTeachersProg1() // Gets all students in programming 1, with all of their teachers
        {
            var students = _context.Students
                .Include(s => s.Enrollments) //include enrollments course
                .ThenInclude(e => e.Course)
                .Include(s => s.Enrollments)// include enrollments teacher
                .ThenInclude(e => e.Teacher)
                .Where(s => s.Enrollments.Any(e => e.Course.CourseName == "Programmering 1"))
                .ToList();

            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // Updates the teacher for a specific student, in programming 1
        public async Task<IActionResult> UpdateTeacherForStudentInCourse(int selectedStudentId, int selectedTeacherId)
        {
            // gets the enrollment for the selected student in programming 1
            var enrollmentToUpdate = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.FkStudentId == selectedStudentId && e.Course.CourseName == "Programmering 1");

            if (enrollmentToUpdate != null)
            {
                var selectedTeacher = await _context.Teachers.FindAsync(selectedTeacherId);

                if (selectedTeacher != null)
                {
                    enrollmentToUpdate.Teacher = selectedTeacher;
                    await _context.SaveChangesAsync();
                }
            }

            var viewModel = new UpdateTeacherViewModel
            {
                Students = await _context.Students
                    .Where(s => s.Enrollments.Any(e => e.Course.CourseName == "Programmering 1"))
                    .ToListAsync(),
                Teachers = await _context.Teachers.ToListAsync(),
                SelectedStudentId = selectedStudentId,
                SelectedTeacherId = selectedTeacherId
            };

            return View(viewModel);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.SchoolClass)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["FkSchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentFirstName,StudentLastName,PersonalNumber,FkSchoolClassId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", student.FkSchoolClassId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["FkSchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", student.FkSchoolClassId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentFirstName,StudentLastName,PersonalNumber,FkSchoolClassId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["FkSchoolClassId"] = new SelectList(_context.SchoolClasses, "SchoolClassId", "SchoolClassName", student.FkSchoolClassId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.SchoolClass)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
