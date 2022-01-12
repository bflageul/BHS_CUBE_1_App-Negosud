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
    public class OrderHistoriesController : Controller
    {
        private readonly NegosudDbContext _context;

        public OrderHistoriesController(NegosudDbContext context)
        {
            _context = context;
        }

        // GET: OrderHistories
        public async Task<IActionResult> Index()
        {
            var negosudDbContext = _context.OrderHistories.Include(o => o.Order).Include(o => o.Users);
            return View(await negosudDbContext.ToListAsync());
        }

        // GET: OrderHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories
                .Include(o => o.Order)
                .Include(o => o.Users)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // GET: OrderHistories/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname");
            return View();
        }

        // POST: OrderHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersId,OrderId")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderHistory.OrderId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", orderHistory.UsersId);
            return View(orderHistory);
        }

        // GET: OrderHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories.FindAsync(id);
            if (orderHistory == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderHistory.OrderId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", orderHistory.UsersId);
            return View(orderHistory);
        }

        // POST: OrderHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersId,OrderId")] OrderHistory orderHistory)
        {
            if (id != orderHistory.UsersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHistoryExists(orderHistory.UsersId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderHistory.OrderId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Firstname", orderHistory.UsersId);
            return View(orderHistory);
        }

        // GET: OrderHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderHistory = await _context.OrderHistories
                .Include(o => o.Order)
                .Include(o => o.Users)
                .FirstOrDefaultAsync(m => m.UsersId == id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return View(orderHistory);
        }

        // POST: OrderHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderHistory = await _context.OrderHistories.FindAsync(id);
            _context.OrderHistories.Remove(orderHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHistoryExists(int id)
        {
            return _context.OrderHistories.Any(e => e.UsersId == id);
        }
    }
}
