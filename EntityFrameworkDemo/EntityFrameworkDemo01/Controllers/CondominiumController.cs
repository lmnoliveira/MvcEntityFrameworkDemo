using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDemo01.Models;
using EntityFrameworkDemo01.Repositories;
using EntityFrameworkDemo01.Repositories.Interfaces;
using System.Data.SqlClient;

namespace EntityFrameworkDemo01.Controllers
{
    public class CondominiumController : Controller
    {
        private readonly ICondominiumRepository db = new CondominiumRepository();

        // GET: Condominiums
        public ActionResult Index()
        {
            return View(db.Read(123456, 
                                pageNumber:0, 
                                rowsPerPage:10,
                                orderBy:new KeyValuePair<string, SortOrder>[] { new KeyValuePair<string, SortOrder>(Common.Helpers.Reflection.ObjectMembers.GetMemberName((Condominium cm) => cm.Id), SortOrder.Ascending) }));
        }

        // GET: Condominiums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominium condominium = db.Read(new int[] { id.Value }).FirstOrDefault();
            if (condominium == null)
            {
                return HttpNotFound();
            }
            return View(condominium);
        }

        // GET: Condominiums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominiums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubsidiaryId,Code,Name")] Condominium condominium)
        {
            if (ModelState.IsValid)
            {
                db.Create(condominium);
                return RedirectToAction("Index");
            }

            return View(condominium);
        }

        // GET: Condominiums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominium condominium = db.Read(new int[] { id.Value }).FirstOrDefault();
            if (condominium == null)
            {
                return HttpNotFound();
            }
            return View(condominium);
        }

        // POST: Condominiums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubsidiaryId,Code,Name")] Condominium condominium)
        {
            if (ModelState.IsValid)
            {
                db.Update(condominium);
                return RedirectToAction("Index");
            }
            return View(condominium);
        }

        // GET: Condominiums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominium condominium = db.Delete(new int[] { id.Value }).FirstOrDefault();
            if (condominium == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
