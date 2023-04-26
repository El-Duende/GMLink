﻿using GMLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GMLink.Controllers
{
    public class AccountDetailsController : Controller
    {
        private IAppUserDetailRepository repository;
        public AccountDetailsController(IAppUserDetailRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.AppUserDetails);
        }
        public ViewResult Edit(int appUserDetailId) =>
            View(repository.AppUserDetails
            .FirstOrDefault(p => p.AppUserDetailID == appUserDetailId));
        [HttpPost]
        public IActionResult Edit(AppUserDetail appUserDetail)
        {
            appUserDetail.Username = AccountController.CurrentUser.UserName;
            if (ModelState.IsValid)
            {
                repository.SaveAppUserDetail(appUserDetail);
                TempData["message"] = $"account changes have been saved";
                return Redirect("/");
            }
            else
            {
                // there is something wrong with the data values
                return View(appUserDetail);
            }
        }
        public ViewResult Create() => View("Edit", new AppUserDetail());
    }
}
