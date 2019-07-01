using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Data;
using Backend5.Models;

namespace Backend5.Controllers
{
    public class MockupsController : Controller
    {

        public IActionResult Home()
        {
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        public IActionResult TaskInfo()
        {
            return this.View();
        }

        public IActionResult TaskAdd()
        {
            return this.View();
        }
    }

}