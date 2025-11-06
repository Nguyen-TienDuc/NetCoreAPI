using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;


namespace DemoMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Student.FirstOrDefaultAsync(s => s.MaSV == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoTen,Lop,NamSinh")] Student student)
        {
            if (ModelState.IsValid)
            {
                // Lấy sinh viên cuối cùng theo mã
                var lastStudent = await _context.Student
                    .OrderByDescending(s => s.MaSV)
                    .FirstOrDefaultAsync();

                int nextNumber = 1;
                if (lastStudent != null)
                {
                    string numberPart = lastStudent.MaSV.Substring(2);
                    nextNumber = int.Parse(numberPart) + 1;
                }

                student.MaSV = "SV" + nextNumber.ToString("D3");

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,HoTen,Lop,NamSinh")] Student student)
        {
            if (id != student.MaSV)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Student.Any(s => s.MaSV == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Student.FirstOrDefaultAsync(s => s.MaSV == id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
