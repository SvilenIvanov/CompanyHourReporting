using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyHourReporting.Data;
using CompanyHourReporting.Models;
using CompanyHourReporting.DataAccess.Repository.IRepository;

namespace CompanyHourReporting.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _context;

        public EmployeeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            
            return View(_context.Employee.GetAll());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee.GetFirstOrDefault(e => e.Id == id) == null)
            {
                return NotFound();
            }

            var employee = _context.Employee.GetFirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Salary,Age,CompanyId")] Employee employee)
        {
            //if (ModelState.IsValid)
            if (true)
            {
                _context.Employee.Add(employee);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company.GetAll(), "Id", "Name", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employee.GetFirstOrDefault(e => e.Id == id) == null)
            {
                return NotFound();
            }

            var employee = _context.Employee.GetFirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company.GetAll(), "Id", "Name", employee.CompanyId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Salary,Age,CompanyId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employee.Update(employee);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company.GetAll(), "Id", "Name", employee.CompanyId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee.GetFirstOrDefault(e => e.Id == id) == null)
            {
                return NotFound();
            }

            var employee = _context.Employee.GetFirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'AppDbContext.Employees'  is null.");
            }
            var employee = _context.Employee.GetFirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return _context.Employee.GetAll().Any(e => e.Id == id);
        }
    }
}
