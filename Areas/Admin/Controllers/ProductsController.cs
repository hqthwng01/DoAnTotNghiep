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
    public class ProductsController : Controller
    {
        private readonly db_DOANTOTNGHIEPContext _context;

        public ProductsController(db_DOANTOTNGHIEPContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var db_DOANTOTNGHIEPContext = _context.Products.Include(p => p.ProductType).Include(p => p.Shipment).Include(p => p.Warehouse);
            return View(await db_DOANTOTNGHIEPContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.Shipment)
                .Include(p => p.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }


        [NoDirectAccess]
        public async Task<IActionResult> Create(int id = 0)
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id");
            ViewData["ShipmentId"] = new SelectList(_context.WarehouseDetails, "Id", "Shipment");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name");
            if (id == 0)
                return View(new Products());

            else
            {
                var imageProduct = await _context.Products.FindAsync(id);
                if (imageProduct == null)
                {
                    return NotFound();
                }

                return View(imageProduct);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Sku,Name,Description,Price,Stock,ProductTypeId,ImageName,WarehouseId,ShipmentId,Status")] Products products)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(products);
                    ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", products.ProductTypeId);
                    ViewData["ShipmentId"] = new SelectList(_context.WarehouseDetails, "Id", "Shipment", products.ShipmentId);
                    ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", products.WarehouseId);
                    await _context.SaveChangesAsync();
                }
                ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", products.ProductTypeId);
                ViewData["ShipmentId"] = new SelectList(_context.WarehouseDetails, "Id", "Shipment", products.ShipmentId);
                ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", products.WarehouseId);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Products.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", products) });
        }


        [NoDirectAccess]
        public async Task<IActionResult> Edit(int id = 0)
        {
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id");
            ViewData["ShipmentId"] = new SelectList(_context.WarehouseDetails, "Id", "Shipment");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name");
            if (id == 0)
                return View(new Products());

            else
            {
                var products = await _context.Products.FindAsync(id);
                if (products == null)
                {
                    return NotFound();
                }

                return View(products);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Name,Description,Price,Stock,ProductTypeId,ImageName,WarehouseId,ShipmentId,Status")] Products products)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    { return NotFound(); }
                    else
                    { throw; }
                }
                ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", products.ProductTypeId);
                ViewData["ShipmentId"] = new SelectList(_context.WarehouseDetails, "Id", "Shipment", products.ShipmentId);
                ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", products.WarehouseId);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Products.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", products) });
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Products.ToList()) });
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
