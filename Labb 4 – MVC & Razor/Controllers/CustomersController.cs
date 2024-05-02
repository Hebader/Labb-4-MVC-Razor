using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb_4___MVC___Razor.Data;
using Labb_4___MVC___Razor.Models;

namespace Labb_4___MVC___Razor.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BorrowedBooks)
                .ThenInclude(bc => bc.Book)
                .FirstOrDefaultAsync(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Email,PhoneNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Add the new customer to the database context
                _context.Add(customer);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Redirect to the list of customers or another page as appropriate
                return RedirectToAction(nameof(Index));
            }

            // If there is a validation error, re-display the form with the input data
            return View(customer);
        }

   

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,Email,PhoneNumber")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    // Lägg till ett felmeddelande om det uppstår ett problem
                    ModelState.AddModelError("", "Ett fel uppstod när kunden skulle uppdateras: " + ex.Message);
                }
            }
            return View(customer);
        }

        //Hämta Customer genom ID

        [HttpGet]
        public async Task<ActionResult> SearchByIdAsync(int id )
        {
            var customer = await _context.Customers
                .Include(c => c.BorrowedBooks)
                .ThenInclude(bc => bc.Book)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            // Returnerar vyn med formuläret för att söka efter en kund
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SearchById(int id)
        {
            // Hitta kunden med det angivna ID:t tillsammans med deras lånade böcker och de associerade böckerna
            var customer = await _context.Customers
                .Include(c => c.BorrowedBooks) // Inkludera lånade böcker
                .ThenInclude(bb => bb.Book) // Inkludera de associerade böckerna
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                // Om kunden hittas, returnera vyn med kundinformationen
                return View("Details", customer);
            }
            else
            {
                // Om kunden inte hittas, visa ett felmeddelande
                ViewBag.ErrorMessage = "Kunden hittades inte.";
                return View();
            }
        }


        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
