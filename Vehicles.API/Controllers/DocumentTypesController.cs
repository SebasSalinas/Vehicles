using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicles.API.Data.Entities;
using Vehicles.API.Data;
using Microsoft.AspNetCore.Authorization;

namespace Vehicles.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocumentTypesController : Controller
    {
        private readonly DataContext _context;

        public DocumentTypesController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.DocumentTypes != null ?
                        View(await _context.DocumentTypes.ToListAsync()) :
                        Problem("Entity set 'DataContext.DocumentTypes'  is null.");
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
        public async Task<IActionResult> Create(DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(documentType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento");
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
            return View(documentType);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentTypes == null)
            {
                return NotFound();
            }

            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }
            return View(documentType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentType documentType)
        {
            if (id != documentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento");
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
            return View(documentType);
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentTypes == null)
            {
                return NotFound();
            }

            var documentType = await _context.DocumentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentType == null)
            {
                return NotFound();
            }
            //_context.VehicleTypes.Remove(vehicleType);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            return View(documentType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentTypes == null)
            {
                return Problem("Entity set 'DataContext.DocumenteType'  is null.");
            }
            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType != null)
            {
                _context.DocumentTypes.Remove(documentType);
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