using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xmall.Models;

namespace xmall.Controllers
{
    public class ProductsController : Controller
    {
        private xMallDBEntities db = new xMallDBEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Batch).Include(p => p.Category).Include(p => p.Color).Include(p => p.Model).Include(p => p.Price).Include(p => p.ProductType).Include(p => p.Storage).Include(p => p.Supplier).Include(p => p.User);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchCode");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Color1");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Model1");
            ViewBag.ProductPrice = new SelectList(db.Prices, "PricesId", "PricesId");
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName");
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,ProductName,ProductImage,UserId,CategoryId,ColorId,ModelId,StorageId,SupplierId,BatchId,SellStartDate,SellEndDtae,IsNew,weigth,ProductUrl,ProductTypeId,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchCode", product.BatchId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Color1", product.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Model1", product.ModelId);
            ViewBag.ProductPrice = new SelectList(db.Prices, "PricesId", "PricesId", product.ProductPrice);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchCode", product.BatchId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Color1", product.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Model1", product.ModelId);
            ViewBag.ProductPrice = new SelectList(db.Prices, "PricesId", "PricesId", product.ProductPrice);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,ProductImage,UserId,CategoryId,ColorId,ModelId,StorageId,SupplierId,BatchId,SellStartDate,SellEndDtae,IsNew,weigth,ProductUrl,ProductTypeId,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchCode", product.BatchId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Color1", product.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Model1", product.ModelId);
            ViewBag.ProductPrice = new SelectList(db.Prices, "PricesId", "PricesId", product.ProductPrice);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
