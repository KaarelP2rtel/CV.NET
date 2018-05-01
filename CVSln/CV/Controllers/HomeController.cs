using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Models;
using DAL.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CV.Controllers
{
    public class HomeController : Controller

    {
        IAppUnitOfWork _uow;
        public HomeController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();

#warning Hardcoded value 1
            vm.Cv = _uow.Cvs.Find(1);
            return View(vm);
        }
    }
}