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

        public async Task<IActionResult> Home()
        {
            return this.View();
        }

        public async Task<IActionResult> Login()
        {
            return this.View();
        }

        public async Task<IActionResult> Register()
        {
            return this.View();
        }

        public async Task<IActionResult> TaskInfo()
        {
            return this.View();
        }

        public async Task<IActionResult> TaskAdd()
        {
            return this.View();
        }
    }

}