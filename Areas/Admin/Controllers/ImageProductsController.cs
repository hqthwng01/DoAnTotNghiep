using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DA_TOTNGHIEP.Models;
using static DA_TOTNGHIEP.Helper;

namespace DA_TOTNGHIEP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageProductsController : Controller
    {
        private readonly db_DOANTOTNGHIEPContext _context;

        public ImageProductsController(db_DOANTOTNGHIEPContext context)
        {
            _context = context;
        }

        // GET: Admin/ImageProducts
        public async Task<IActionResult> Index()
        {
            var db_DOANTOTNGHIEPContext = _context.ImageProduct.Include(i => i.Products);
            return View(await db_DOANTOTNGHIEPContext.ToListAsync());
        }

        // GET: Admin/ImageProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageProduct = await _context.ImageProduct
                .Include(i => i.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageProduct == null)
            {
                return NotFound();
            }

            return View(imageProduct);
        }

        [NoDirectAccess]
        public async Task<IActionResult> ImageAdd(int id = 0)
        {
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", "ProductsID");
            if (id == 0)
            return View(new ImageProduct());
            
            else
            {
                var imageProduct = await _context.ImageProduct.FindAsync(id);
                if (imageProduct == null)
                {
                    return NotFound();
                }

                return View(imageProduct);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageAdd(int id, [Bind("Id,ImageName,ProductsID,Status")] ImageProduct imageProduct)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(imageProduct);
                    ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", imageProduct.ProductsID);
                    await _context.SaveChangesAsync();
                }
                ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", imageProduct.ProductsID);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ImageProduct.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "ImageAdd", imageProduct) });
        }

        [NoDirectAccess]
        public async Task<IActionResult> ImageEdit(int id = 0)
        {
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", "ProductsID");
            if (id == 0)
                return View(new ImageProduct());

            else
            {
                var imageProduct = await _context.ImageProduct.FindAsync(id);
                if (imageProduct == null)
                {
                    return NotFound();
                }

                return View(imageProduct);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImageEdit(int id, [Bind("Id,ImageName,ProductsID,Status")] ImageProduct imageProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageProductExists(imageProduct.Id))
                    { return NotFound(); }
                    else
                    { throw; }
                }
                ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", imageProduct.ProductsID);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ImageProduct.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "ImageEdit", imageProduct) });
        }


        // POST: Admin/ImageProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageProduct = await _context.ImageProduct.FindAsync(id);
            _context.ImageProduct.Remove(imageProduct);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.ImageProduct.ToList()) });
        }

        private bool ImageProductExists(int id)
        {
            return _context.ImageProduct.Any(e => e.Id == id);
        }
    }
}
