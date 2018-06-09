using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDoisV.Models.Cadastros;
using DAL.Context;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDoisV.Controllers
{
    public class BemController : Controller
    {
        public BemController(C2VContext dbContext)
        {
            _RepositoryBem = new RepositoryBem(dbContext);
        }
        private RepositoryBem _RepositoryBem;

        public async Task<IActionResult> Index()
        {
            return View(await _RepositoryBem.GetAllOrderByDescricao().ToListAsync());
        }

        public async Task<IActionResult> Create(BemViewModel model)
        {
            return View();
        }
    }
}