﻿using System.Diagnostics;
using ContactManager.V1.Models;
using ContactManager.V1.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.V1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        try
        {
            using var context = new AppDbContext();
            var contacts = context.Contacts.ToList();
            return View(contacts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await using var context = new AppDbContext();
            await context.AddAsync(contact);
            await context.SaveChangesAsync();

            ViewBag.Message = "Record saved successfully";
        }

        return View(contact);
    }


    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return View();
        await using var context = new AppDbContext();

        var recordToDelete = context.Contacts.FirstOrDefault(x => x.Id == id);
        if (recordToDelete == null) return View();
        context.Contacts.Remove(recordToDelete);
        await context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}