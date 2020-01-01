using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using EntityFrameworkDemo.Repositories;
using EntityFrameworkDemo.Repositories.Interfaces;
using EntityFrameworkDemo.DomainModels;
using System.Data.SqlClient;
using Common.Helpers.Reflection;
using Common.Helpers;
using MvcDemo.Resources;

namespace MvcDemo.Controllers
{
    public class CondominiumController : Controller
    {
        private readonly ICondominiumRepository _condominiumRepo = new CondominiumRepository();
        private AutoMapper<Condominium, CondominiumViewModel> _mapCondominium2CondominiumMV { get; set; }
        private AutoMapper<CondominiumViewModel, Condominium> _mapCondominiumMV2Condominium { get; set; }

        public CondominiumController()
        {
            Inititalize();
        }

        public CondominiumController(ICondominiumRepository condominiumRepository)
        {
            Inititalize();
            this._condominiumRepo = condominiumRepository;
        }

        private void Inititalize()
        {
            _mapCondominium2CondominiumMV = new AutoMapper<Condominium, CondominiumViewModel>();
            _mapCondominiumMV2Condominium = new AutoMapper<CondominiumViewModel, Condominium>();
        }

        // GET: Condominiums
        public ActionResult Index()
        {
            return View(_mapCondominium2CondominiumMV.Run(
                        _condominiumRepo.Read(
                            0,
                            pageNumber: 0,
                            rowsPerPage: 10,
                            orderBy: new KeyValuePair<string, SortOrder>[] { new KeyValuePair<string, SortOrder>(ObjectMembers.GetMemberName((CondominiumViewModel cm) => cm.Name), SortOrder.Ascending) })));
        }

        // GET: Condominiums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominium condominiumDomainModel = _condominiumRepo.Read(new int[] { id.Value }).FirstOrDefault();
            CondominiumViewModel condominiumViewModel = _mapCondominium2CondominiumMV.Run(condominiumDomainModel);
            if (condominiumViewModel == null)
            {
                return HttpNotFound();
            }
            return View(condominiumViewModel);
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
        public ActionResult Create([Bind(Include = "Id,SubsidiaryId,Code,Name")] CondominiumViewModel condominium)
        {
            if (ModelState.IsValid)
            {
                _condominiumRepo.Create(_mapCondominiumMV2Condominium.Run(condominium));
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
            Condominium condominiumDomainModel = _condominiumRepo.Read(new int[] { id.Value }).FirstOrDefault();
            if (condominiumDomainModel == null)
            {
                return HttpNotFound();
            }
            return View(_mapCondominium2CondominiumMV.Run(condominiumDomainModel));
        }

        // POST: Condominiums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubsidiaryId,Code,Name")] CondominiumViewModel condominium)
        {
            if (ModelState.IsValid)
            {
                _condominiumRepo.Update(_mapCondominiumMV2Condominium.Run(condominium));
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
            Condominium condominiumDomainModel = _condominiumRepo.Delete(new int[] { id.Value }).FirstOrDefault();
            if (condominiumDomainModel == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
