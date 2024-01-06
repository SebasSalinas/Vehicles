using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProceduresController : Controller
    {
        private readonly DataContext _context;

        public ProceduresController(DataContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
            return _context.Procedures != null ?
                        View(await _context.Procedures.ToListAsync()) :
                        Problem("Entity set 'DataContext.Procedures'  is null.");
        }

        //// GET: VehicleTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.VehicleTypes == null)
        //    {
        //        return NotFound();
        //    }

        //    var vehicleType = await _context.VehicleTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (vehicleType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vehicleType);
        //}

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(procedure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este procedimiento");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(procedure);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedures == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            return View(procedure);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Procedure procedure)
        {
            if (id != procedure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe el Procedimiento");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!VehicleTypeExists(vehicleType.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

            }
            return View(procedure);
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedures == null)
            {
                return NotFound();
            }

            Procedure? procedure = await _context.Procedures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }
            //_context.VehicleTypes.Remove(vehicleType);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            return View(procedure);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedures == null)
            {
                return Problem("Entity set 'DataContext.procedures'  is null.");
            }
            var procedure = await _context.Procedures.FindAsync(id);
            if (procedure != null)
            {
                _context.Procedures.Remove(procedure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool VehicleTypeExists(int id)
        //{
        //    return (_context.VehicleTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
