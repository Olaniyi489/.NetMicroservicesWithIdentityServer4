using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeMvcClient.Data;
using EmployeeMvcClient.Models;

namespace EmployeeMvcClient.Controllers
{
    public class EmployeeMvcsController : Controller
    {
        private readonly EmployeeMvcClientContext _context;

        public EmployeeMvcsController(EmployeeMvcClientContext context)
        {
            _context = context;
        }

        // GET: EmployeeMvcs
        public async Task<IActionResult> Index()
        {
              return View(await _context.EmployeeMvc.ToListAsync());
        }

        // GET: EmployeeMvcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeMvc == null)
            {
                return NotFound();
            }

            var employeeMvc = await _context.EmployeeMvc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMvc == null)
            {
                return NotFound();
            }

            return View(employeeMvc);
        }

        // GET: EmployeeMvcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMvcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,JobTitle,JoinedDate,Department")] EmployeeMvc employeeMvc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeMvc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMvc);
        }

        // GET: EmployeeMvcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeMvc == null)
            {
                return NotFound();
            }

            var employeeMvc = await _context.EmployeeMvc.FindAsync(id);
            if (employeeMvc == null)
            {
                return NotFound();
            }
            return View(employeeMvc);
        }

        // POST: EmployeeMvcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,JobTitle,JoinedDate,Department")] EmployeeMvc employeeMvc)
        {
            if (id != employeeMvc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMvc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMvcExists(employeeMvc.Id))
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
            return View(employeeMvc);
        }

        // GET: EmployeeMvcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeMvc == null)
            {
                return NotFound();
            }

            var employeeMvc = await _context.EmployeeMvc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMvc == null)
            {
                return NotFound();
            }

            return View(employeeMvc);
        }

        // POST: EmployeeMvcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeMvc == null)
            {
                return Problem("Entity set 'EmployeeMvcClientContext.EmployeeMvc'  is null.");
            }
            var employeeMvc = await _context.EmployeeMvc.FindAsync(id);
            if (employeeMvc != null)
            {
                _context.EmployeeMvc.Remove(employeeMvc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMvcExists(int id)
        {
          return _context.EmployeeMvc.Any(e => e.Id == id);
        }
    }
}
