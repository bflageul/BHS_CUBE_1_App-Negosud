using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NegosudApp.Migrations;
using NegosudApp.Models;

namespace NegosudApp.Views
{
    public class AddressUsersController : Controller
    {
        private readonly NegosudDbContext _context;

        public AddressUsersController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: AddressUsers
        public async Task<IActionResult> Index()
        {
            var negosudDbContext = _context.AddressUsers.Include(a => a.Address).Include(a => a.Users);
            return View(await negosudDbContext.ToListAsync());
        }

        // GET: AddressUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressUser = await _context.AddressUsers
                .Include(a => a.Address)
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (addressUser == null)
            {
                return NotFound();
            }

            return View(addressUser);
        }

        // GET: AddressUsers/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City");
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname");
            return View();
        }

        // POST: AddressUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersId,AddressId")] AddressUser addressUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City", addressUser.AddressId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", addressUser.UsersId);
            return View(addressUser);
        }

        // GET: AddressUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressUser = await _context.AddressUsers.FindAsync(id);
            if (addressUser == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City", addressUser.AddressId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", addressUser.UsersId);
            return View(addressUser);
        }

        // POST: AddressUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,AddressId")] AddressUser addressUser)
        {
            if (id != addressUser.AddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressUserExists(addressUser.AddressId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "City", addressUser.AddressId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", addressUser.UsersId);
            return View(addressUser);
        }

        // GET: AddressUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressUser = await _context.AddressUsers
                .Include(a => a.Address)
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (addressUser == null)
            {
                return NotFound();
            }

            return View(addressUser);
        }

        // POST: AddressUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressUser = await _context.AddressUsers.FindAsync(id);
            _context.AddressUsers.Remove(addressUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressUserExists(int id)
        {
            return _context.AddressUsers.Any(e => e.AddressId == id);
        }
    }
}
