﻿using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GMLink.Controllers
{
    public class GMBookingsController : Controller
    {
        public IActionResult ViewBookings()
        {
            return View();
        }
    }
}