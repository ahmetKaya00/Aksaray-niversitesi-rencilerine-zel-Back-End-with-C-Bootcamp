﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ETicaret.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicaret.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {

    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;

        if(!String.IsNullOrEmpty(searchString)){
            products = products.Where(p=>p.Name!.ToLower().Contains(searchString)).ToList();
        }

        if(!String.IsNullOrEmpty(category)&& category != "0"){
            products = products.Where(p=>p.CategoryId == int.Parse(category)).ToList();
        }

      //  ViewBag.Categories = ;

      var model = new ProductViewModel{
        Products = products,
        Categories = Repository.Categories,
        SelectedCategory = category
      };
        return View(model);
    }

    public IActionResult Admin()
    {
        return View(Repository.Products);
    }

    [HttpGet]
    public IActionResult Create(){
        
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile){

        var allowedExtensions = new[] {".jpg",".jpeg",".png"};
        var extension = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);

        if(imageFile != null){
            if(!allowedExtensions.Contains(extension)){
                ModelState.AddModelError("","Geçerli bir resim seçiniz.");
            }
        }
        if(ModelState.IsValid){
            if(imageFile != null){
            using(var stream = new FileStream(path, FileMode.Create)){
                await imageFile.CopyToAsync(stream);
            }}
            model.Image = randomFileName;
            model.ProductId = Repository.Products.Count;
            Repository.CreateProduct(model);
            return RedirectToAction("Admin");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View(model);
    }

}