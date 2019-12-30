using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WT03.Data;
using WT03.Models;

namespace WT03.Controllers
{
    [Authorize]
    public class BeeCountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeeCountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BeeCount
        public async Task<IActionResult> Index([FromServices]UserManager<UserData> userManager)
        {
            var currentUser = await userManager.GetUserAsync(User);
            return View(await _context.BeeCounts.Where(b => b.Author == currentUser)
                .ToListAsync());
            //return View(await _context.BeeCounts.ToListAsync());
        }

        // GET: BeeCount/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beeCountModel = await _context.BeeCounts
                .FirstOrDefaultAsync(m => m.BeeCountModelId == id);
            if (beeCountModel == null)
            {
                return NotFound();
            }

            return View(beeCountModel);
        }

        // GET: BeeCount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeeCount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeeHiveName,CountTime,NumberOfMidgets,ObservationDays,Comments")] BeeCountModel beeCountModel, [FromServices]UserManager<UserData> userManager)
        {
            if (ModelState.IsValid)
            {
                beeCountModel.Author = await userManager.GetUserAsync(User);
                beeCountModel.IdOfAuthor = beeCountModel.Author.UserDataId;
                _context.Add(beeCountModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beeCountModel);
        }

        // GET: BeeCount/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beeCountModel = await _context.BeeCounts.FindAsync(id);
            if (beeCountModel == null)
            {
                return NotFound();
            }
            return View(beeCountModel);
        }

        // POST: BeeCount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BeeCountModelId,BeeHiveName,CountTime,NumberOfMidgets,ObservationDays,Comments")] BeeCountModel beeCountModel)
        {
            if (id != beeCountModel.BeeCountModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beeCountModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeeCountModelExists(beeCountModel.BeeCountModelId))
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
            return View(beeCountModel);
        }

        // GET: BeeCount/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beeCountModel = await _context.BeeCounts
                .FirstOrDefaultAsync(m => m.BeeCountModelId == id);
            if (beeCountModel == null)
            {
                return NotFound();
            }

            return View(beeCountModel);
        }

        // POST: BeeCount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var beeCountModel = await _context.BeeCounts.FindAsync(id);
            _context.BeeCounts.Remove(beeCountModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeeCountModelExists(long id)
        {
            return _context.BeeCounts.Any(e => e.BeeCountModelId == id);
        }
    }
}
