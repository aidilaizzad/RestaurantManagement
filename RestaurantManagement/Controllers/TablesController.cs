using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    [Route("[controller]")]
    public class TablesController : Controller
    {
        private readonly RestaurantManagementContext _context;

        public TablesController(RestaurantManagementContext context)
        {
            _context = context;
        }

        // GET: Tables
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tables = await _context.Tables.ToListAsync();
            return View(tables); // Returns the list view of subjects
        }

        // GET: Tables/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var table= await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table); // Returns the details view of a specific tables
        }

        // GET: Tables/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new tables
        }

        // POST: Tables/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the table list
            }
            return View(table);
        }

        // GET: Tables/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var table= await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table); // Returns the edit view for a specific table
        }

        // POST: Tables/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Table table)
        {
            if (id != table.TableID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the table list
            }
            return View(table);
        }

        // GET: Tables/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var table= await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table); // Returns the delete confirmation view
        }

        // POST: Tables/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the subject list
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.TableID == id);
        }
    }
}