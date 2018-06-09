using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDoisV.Controllers
{
    public class GrupoBemController : Controller
    {
        public GrupoBemController(C2VContext dbContext)
        {
            _RepositoryGrupoBem = new RepositoryGrupoBem(dbContext);
        }

        private RepositoryGrupoBem _RepositoryGrupoBem;

        public async Task<IActionResult> Index()
        {
            return View(await _RepositoryGrupoBem.GetAllOrderByDescricao().ToListAsync());
        }
    }
}