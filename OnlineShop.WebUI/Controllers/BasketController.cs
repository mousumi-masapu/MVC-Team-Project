﻿using OnlineShop.Core.Contarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.WebUI.Controllers
{
    public class BasketController:Controller
    {
        // GET: Basket
        IBasketService basketService;
        public BasketController(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }
        

        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
        public ActionResult RemoveFromBasket1()
        {
            basketService.RemoveFromBasket1(this.HttpContext);
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}