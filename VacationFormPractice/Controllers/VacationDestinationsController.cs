using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacationFormPractice.Data;
using VacationFormPractice.Models;

namespace VacationFormPractice.Controllers
{
    public class VacationDestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationDestinationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationDestinations
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacationPlaces.ToListAsync());
        }

        // GET: VacationDestinations/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return Content("Unable to retrieve vacation. Please enter the id using ?id= [number]");
            }

            var vacationPlaces = await _context.VacationPlaces
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (vacationPlaces == null)
            {
                return Content("Invalid vacation place");
            }

            return View(vacationPlaces);
        }

        // GET: VacationDestinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VacationDestinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationID,Name,Attractions,datetime")] VacationPlaces vacationPlaces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationPlaces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacationPlaces);
        }

        // GET: VacationDestinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationPlaces = await _context.VacationPlaces.SingleOrDefaultAsync(m => m.DestinationID == id);
            if (vacationPlaces == null)
            {
                return NotFound();
            }
            return View(vacationPlaces);
        }

        // POST: VacationDestinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationID,Name,Attractions,datetime")] VacationPlaces vacationPlaces)
        {
            if (id != vacationPlaces.DestinationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationPlaces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationPlacesExists(vacationPlaces.DestinationID))
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
            return View(vacationPlaces);
        }

        // GET: VacationDestinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacationPlaces = await _context.VacationPlaces
                .SingleOrDefaultAsync(m => m.DestinationID == id);
            if (vacationPlaces == null)
            {
                return NotFound();
            }

            return View(vacationPlaces);
        }

        // POST: VacationDestinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacationPlaces = await _context.VacationPlaces.SingleOrDefaultAsync(m => m.DestinationID == id);
            _context.VacationPlaces.Remove(vacationPlaces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationPlacesExists(int id)
        {
            return _context.VacationPlaces.Any(e => e.DestinationID == id);
        }
    }
}
