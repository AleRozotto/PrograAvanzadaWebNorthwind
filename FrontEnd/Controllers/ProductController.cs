﻿using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {

        IProductHelper ProductHelper;
        ICategoryHelper CategoryHelper;
        ISupplierHelper SupplierHelper;

        public ProductController(IProductHelper _productHelper
                                   , ICategoryHelper _categoryHelper
                                   , ISupplierHelper _supplierHelper
               )
        {
            ProductHelper = _productHelper;
            CategoryHelper = _categoryHelper;
            SupplierHelper = _supplierHelper;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductViewModel> lista = ProductHelper.GetAll();
            return View(lista);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
           var product = ProductHelper.GetById(id);
            product.Category = CategoryHelper.GetCategory((int)product.CategoryId);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {



            ProductViewModel product = new ProductViewModel();
            product.Categories = CategoryHelper.GetCategories();
            product.Suppliers = SupplierHelper.GetAll();



            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                ProductHelper.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = ProductHelper.GetById(id);
            product.Suppliers = SupplierHelper.GetAll();
            product.Categories = CategoryHelper.GetCategories();

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                ProductHelper.EdiProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = ProductHelper.GetById(id);

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                ProductHelper.DeleteProduct(product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
