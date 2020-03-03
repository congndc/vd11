using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vd11.Context;
using vd11.Models;

namespace vd11.Controllers
{
    public class CongTiesController : Controller
    {
        private readonly NewContext _context;

        public CongTiesController(NewContext context)
        {
            _context = context;
        }

        // GET: CongTies
        public async Task<IActionResult> Index()
        {
            var newContext = _context.CongTy.Include(c => c.NhanVien).Include(c => c.ThamNien);
            return View(await newContext.ToListAsync());
        }

        // GET: CongTies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congTy = await _context.CongTy
                .Include(c => c.NhanVien)
                .Include(c => c.ThamNien)
                .FirstOrDefaultAsync(m => m.CongTyID == id);
            if (congTy == null)
            {
                return NotFound();
            }

            return View(congTy);
        }

        // GET: CongTies/Create
        public IActionResult Create()
        {
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "NhanVienID", "TenNhanVien");
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID");
            return View();
        }

        // POST: CongTies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CongTyID,TenCongTy,NhanVienID,ThamNienID")] CongTy congTy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congTy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "NhanVienID", "TenNhanVien", congTy.NhanVienID);
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", congTy.ThamNienID);
            return View(congTy);
        }

        // GET: CongTies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congTy = await _context.CongTy.FindAsync(id);
            if (congTy == null)
            {
                return NotFound();
            }
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "NhanVienID", "TenNhanVien", congTy.NhanVienID);
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", congTy.ThamNienID);
            return View(congTy);
        }

        // POST: CongTies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CongTyID,TenCongTy,NhanVienID,ThamNienID")] CongTy congTy)
        {
            if (id != congTy.CongTyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congTy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongTyExists(congTy.CongTyID))
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
            ViewData["NhanVienID"] = new SelectList(_context.NhanVien, "NhanVienID", "TenNhanVien", congTy.NhanVienID);
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", congTy.ThamNienID);
            return View(congTy);
        }

        // GET: CongTies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congTy = await _context.CongTy
                .Include(c => c.NhanVien)
                .Include(c => c.ThamNien)
                .FirstOrDefaultAsync(m => m.CongTyID == id);
            if (congTy == null)
            {
                return NotFound();
            }

            return View(congTy);
        }

        // POST: CongTies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congTy = await _context.CongTy.FindAsync(id);
            _context.CongTy.Remove(congTy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongTyExists(int id)
        {
            return _context.CongTy.Any(e => e.CongTyID == id);
        }

       
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
   
    }
}
