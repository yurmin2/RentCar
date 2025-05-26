using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class LeaseAgreementsController : Controller
    {
        private readonly RentCarContext _context;

        public LeaseAgreementsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: LeaseAgreements
        public async Task<IActionResult> Index()
        {
            var rentCarContext = _context.LeaseAgreement.Include(l => l.Car).Include(l => l.Tenant);
            return View(await rentCarContext.ToListAsync());
        }

        // GET: LeaseAgreements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaseAgreement = await _context.LeaseAgreement
                .Include(l => l.Car)
                .Include(l => l.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaseAgreement == null)
            {
                return NotFound();
            }

            return View(leaseAgreement);
        }

        // GET: LeaseAgreements/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "Id");
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id");
            return View();
        }

        // POST: LeaseAgreements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataTime,Price,TenantId,CarId")] LeaseAgreement leaseAgreement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaseAgreement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "Id", leaseAgreement.CarId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id", leaseAgreement.TenantId);
            return View(leaseAgreement);
        }

        // GET: LeaseAgreements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaseAgreement = await _context.LeaseAgreement.FindAsync(id);
            if (leaseAgreement == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "Id", leaseAgreement.CarId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id", leaseAgreement.TenantId);
            return View(leaseAgreement);
        }

        // POST: LeaseAgreements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataTime,Price,TenantId,CarId")] LeaseAgreement leaseAgreement)
        {
            if (id != leaseAgreement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaseAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaseAgreementExists(leaseAgreement.Id))
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
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "Id", leaseAgreement.CarId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id", leaseAgreement.TenantId);
            return View(leaseAgreement);
        }

        // GET: LeaseAgreements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaseAgreement = await _context.LeaseAgreement
                .Include(l => l.Car)
                .Include(l => l.Tenant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaseAgreement == null)
            {
                return NotFound();
            }

            return View(leaseAgreement);
        }

        // POST: LeaseAgreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaseAgreement = await _context.LeaseAgreement.FindAsync(id);
            if (leaseAgreement != null)
            {
                _context.LeaseAgreement.Remove(leaseAgreement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaseAgreementExists(int id)
        {
            return _context.LeaseAgreement.Any(e => e.Id == id);
        }
    }
}
