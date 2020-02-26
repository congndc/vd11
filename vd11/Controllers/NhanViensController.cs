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
    public class NhanViensController : Controller
    {
        private readonly NewContext _context;

        public NhanViensController(NewContext context)
        {
            _context = context;
        }

        // GET: NhanViens
        public async Task<IActionResult> Index()
        {
            var newContext = _context.NhanVien.Include(n => n.ThamNien);
            return View(await newContext.ToListAsync());
        }

        // GET: NhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.ThamNien)
                .FirstOrDefaultAsync(m => m.NhanVienID == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public IActionResult Create()
        {
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NhanVienID,TenNhanVien,NamSinh,GioiTinh,ChucVu,VeHuu,ThamNienID")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", nhanVien.ThamNienID);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", nhanVien.ThamNienID);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NhanVienID,TenNhanVien,NamSinh,GioiTinh,ChucVu,VeHuu,ThamNienID")] NhanVien nhanVien)
        {
            if (id != nhanVien.NhanVienID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.NhanVienID))
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
            ViewData["ThamNienID"] = new SelectList(_context.ThamNien, "ThamNienID", "ThamNienID", nhanVien.ThamNienID);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.ThamNien)
                .FirstOrDefaultAsync(m => m.NhanVienID == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanVien.FindAsync(id);
            _context.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanVien.Any(e => e.NhanVienID == id);
        }
    }
}
