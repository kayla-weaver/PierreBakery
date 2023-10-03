using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{

  public class OrdersController : Controller
  {
    [HttpGet("/vendor/{id}/order/new")]
    public ActionResult newOrder(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      return View(vendor);
    }

    [HttpPost("/vendor/{id}/order/new")]
    public ActionResult CreateOrder(string title, string description, int price, DateTime orderDate, int vendorId)
    {
      Vendor vendor = Vendor.GetVendorWithId(vendorId);
      Order order = new Order(title, description, price, vendor.GetOrderCount(), vendor.Name, orderDate, vendor.Id);
      vendor.AddOrder(order);
      return View("ShowOrder", order);
    }

    [HttpGet("/vendor/{id}/order/{oid}")]
    public ActionResult ShowOrder(int id, int oid)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      Order order = vendor.GetOrderWithId(oid);
      return View(order);
    }
  }

}