using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SingleToDoWebApp.Models;

namespace SingleToDoWebApp.Controllers
{
    public class ToDoStatementsController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoStatementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ToDoStatements
        public async Task<IActionResult> Index()
        {
              return _context.ToDoStatements != null ? 
                          View(await _context.ToDoStatements.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ToDoStatements'  is null.");
        }

        // GET: ToDoStatements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoStatements == null)
            {
                return NotFound();
            }

            var toDoStatement = await _context.ToDoStatements
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (toDoStatement == null)
            {
                return NotFound();
            }

            return View(toDoStatement);
        }

        // GET: ToDoStatements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoStatements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToDo,date")] ToDoStatement toDoStatement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoStatement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoStatement);
        }

        // GET: ToDoStatements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoStatements == null)
            {
                return NotFound();
            }

            var toDoStatement = await _context.ToDoStatements.FindAsync(id);
            if (toDoStatement == null)
            {
                return NotFound();
            }
            return View(toDoStatement);
        }

        // POST: ToDoStatements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,ToDo,date")] ToDoStatement toDoStatement)
        {
            if (id != toDoStatement.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoStatement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoStatementExists(toDoStatement.TaskId))
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
            return View(toDoStatement);
        }

        // GET: ToDoStatements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDoStatements == null)
            {
                return NotFound();
            }

            var toDoStatement = await _context.ToDoStatements
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (toDoStatement == null)
            {
                return NotFound();
            }

            return View(toDoStatement);
        }

        // POST: ToDoStatements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDoStatements == null)
            {
                return Problem("Entity set 'AppDbContext.ToDoStatements'  is null.");
            }
            var toDoStatement = await _context.ToDoStatements.FindAsync(id);
            if (toDoStatement != null)
            {
                _context.ToDoStatements.Remove(toDoStatement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoStatementExists(int id)
        {
          return (_context.ToDoStatements?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
