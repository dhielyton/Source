using ControleDoisV.Models;
using DAL.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDoisV.Data
{
    public class DBContextApplication : IdentityDbContext<UserApplication>
    {
        public DBContextApplication(DbContextOptions<DBContextApplication> options) : base(options)
        {

        }
    }
}
