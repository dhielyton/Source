﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Repository;
using Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDoisV.Controllers
{
    [Authorize]
    public class OperacaoBemController : Controller
    {
        public OperacaoBemController(C2VContext dbContext)
        {
            _Repository = new RepositoryOperacaoBem(dbContext);
        }
        private RepositoryOperacaoBem _Repository;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _Repository.GetAllOrderByData().ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao, Status")]OperacaoBem model)
        {
            try
            {
                if (model == null)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    await _Repository.Save(model);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? Id)
        {
            return await ActionForId((long)Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OperacaoBem model, long Id)
        {
            try
            {
                if (model.OperacaoBemID != Id)
                    return NotFound();
                if (ModelState.IsValid)
                {
                    await _Repository.Update(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.Clear();
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long? Id)
        {
            return await ActionForId(Id);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? Id)
        {
            return await ActionForId((long)Id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long Id)
        {
            var model = await _Repository.Delete((long)Id);
            TempData["Message"] = $"Grupo de Bem {model.Tomador.Nome.ToUpper()} foi removido";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> ActionForId(long? Id)
        {
            if (Id == null)
                return NotFound();

            var model = await _Repository.LocalizarPorId((long)Id);

            return View(model);
        }
    }
}