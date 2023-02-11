using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyHourReporting.Data;
using CompanyHourReporting.Models;
using CompanyHourReporting.DataAccess.Repository;
using CompanyHourReporting.DataAccess.Repository.IRepository;

namespace CompanyHourReporting.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _context;

        public CompanyController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
              return View(_context.Company.GetAll());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company.GetFirstOrDefault(m => m.Id == id) == null)
            {
                return NotFound();
            }

            var company = _context.Company.GetFirstOrDefault(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Add(company);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Company.GetFirstOrDefault(m => m.Id == id) == null)
            {
                return NotFound();
            }

            var company = _context.Company.GetFirstOrDefault(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Company.Update(company);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Company.GetFirstOrDefault(m => m.Id == id) == null)
            {
                return NotFound();
            }

            var company = _context.Company.GetFirstOrDefault(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Company.GetFirstOrDefault(m => m.Id == id) == null)
            {
                return Problem("Entity set 'AppDbContext.Companies'  is null.");
            }
            var company = _context.Company.GetFirstOrDefault(m => m.Id == id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return _context.Company.GetAll().Any(e => e.Id == id);
        }
    }
}
