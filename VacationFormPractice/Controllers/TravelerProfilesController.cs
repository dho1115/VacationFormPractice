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
    public class TravelerProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelerProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelerProfiles
        public async Task<IActionResult> Index()
        {           
            return View(await _context.travelerProfiles.ToListAsync()); //NOTE: Where did we get travelerProfiles from? This came from the ApplicationDbContext that was generated as the name for the dbSet. It is also the name of the table
        }

        //FORM CONFIRMATION: CONFIRM IF INFORMATION ON FORM IS CORRECT.

        List<TravelerProfile> NewProfile = new List<TravelerProfile>();

        public IActionResult FormConfirmation(string fname, string lname, string destination, decimal Budget, string Email, int phone)        
        {
            NewProfile.Add(new TravelerProfile
            {
                FirstName = fname,
                LastName = lname,
                DreamDestination = destination,
                budget = Budget,
                email = Email,
                phoneNumber = phone
            });

            return View(NewProfile);
        }

        // GET: TravelerProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelerProfile = await _context.travelerProfiles
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelerProfile == null)
            {
                return NotFound();
            }

            return View(travelerProfile);
        }

        private TravelerProfile db = new TravelerProfile();

        // GET: TravelerProfiles/Create
        
        public IActionResult Create() //NOTE: CREATE the form for the traveler.
        {
            //_context.SaveChanges();
            return View();
        }

        // POST: TravelerProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //NOTE: The bottom method (Create) returns to us the LIST of ALL the travelers generated from the above list.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,DreamDestination,email,phoneNumber,budget")] TravelerProfile travelerProfile) //NOTE: To ADD A COLUMN: Update the bind.
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelerProfile); // <= Add new value to table. NOTE:
                await _context.SaveChangesAsync(); // <= Save Changes. NOTE: 
                return RedirectToAction(nameof(Index));
            }
            return View(travelerProfile);
        }

        // GET: TravelerProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Content("Please enter the id number of the person you want to edit in the URL search bar.");
            }

            var travelerProfile = await _context.travelerProfiles.SingleOrDefaultAsync(m => m.id == id);

            if (travelerProfile == null)
            {
                return Content("ID number is not found.");
            }
            return View(travelerProfile);
        }

        // POST: TravelerProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,DreamDestination,budget")] TravelerProfile travelerProfile)
        {
            if (id != travelerProfile.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelerProfileExists(travelerProfile.id))
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
            return View(travelerProfile);
        }

        // GET: TravelerProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelerProfile = await _context.travelerProfiles
                .SingleOrDefaultAsync(m => m.id == id);
            if (travelerProfile == null)
            {
                return NotFound();
            }

            return View(travelerProfile);
        }

        // POST: TravelerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelerProfile = await _context.travelerProfiles.SingleOrDefaultAsync(m => m.id == id);
            _context.travelerProfiles.Remove(travelerProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelerProfileExists(int id)
        {
            return _context.travelerProfiles.Any(e => e.id == id);
        }
    }
}
