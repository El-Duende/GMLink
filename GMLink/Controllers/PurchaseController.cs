﻿using Microsoft.AspNetCore.Mvc;
using GMLink.Models;
using GMLink.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace GMLink.Controllers
{


    public class PurchaseController : Controller
    {
        private IPurchaseRepository repository;
        private IReservationRepository repositoryR;
        private Cart cart;
        public PurchaseController(IPurchaseRepository repoService, IReservationRepository repo, Cart cartService)
        {
            repositoryR = repo;
            repository = repoService;
            cart = cartService;
        }
        [Authorize]
        public ViewResult Checkout() => View(new Purchase());

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                decimal price = 0;
                purchase.UserName = AccountController.CurrentUser.UserName;
                purchase.Lines = cart.Lines.ToArray();
                repository.SaveOrder(purchase);
                TempData["message"] = $"reservation number {purchase.PurchaseID} has been saved";
                cart.Clear();
                foreach (var line in purchase.Lines)
                {
                    Reservation reservation = line.Reservation;
                    reservation.Description = AccountController.CurrentUser.UserName;
                    price += reservation.Price;
                    repositoryR.SaveReservation(reservation);
                }
                purchase.Total = price;
                return View("Completed");
            }
            else
            {
                return View(purchase);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}