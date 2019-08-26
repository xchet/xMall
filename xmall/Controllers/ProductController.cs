using PagedList;
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
    public class ProductController : Controller
    {
        private xMallDBEntities db = new xMallDBEntities();
        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Batch).Include(p => p.Category).Include(p => p.Color).Include(p => p.Model).Include(p => p.Price).Include(p => p.ProductType).Include(p => p.Storage).Include(p => p.Supplier).Include(p => p.User);
            return View(products.ToList());
        }

        public PartialViewResult ProductListPartial(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;

            var productList = db.Products.OrderByDescending(x => x.ProductId).ToPagedList(pageNumber, pageSize);
            return PartialView(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
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

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.BatchId = new SelectList(db.Batches, "BatchId", "BatchCode");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.ColorId = new SelectList(db.Colors, "ColorId", "Color1");
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Model1");
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName");
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,ProductName,Image,Price,UserId,CategoryId,ColorId,ModelId,StorageId,SupplierId,BatchId,SellStartDate,SellEndDtae,IsNew,PurchasePrice,weigth,ProductUrl,ProductTypeId,Quantity")] Product product)
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
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // GET: Product/Edit/5
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
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,ProductName,Image,Price,UserId,CategoryId,ColorId,ModelId,StorageId,SupplierId,BatchId,SellStartDate,SellEndDtae,IsNew,PurchasePrice,weigth,ProductUrl,ProductTypeId,Quantity")] Product product)
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
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "ProductTypeName", product.ProductTypeId);
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "Storage1", product.StorageId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", product.SupplierId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", product.UserId);
            return View(product);
        }

        // GET: Product/Delete/5
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
