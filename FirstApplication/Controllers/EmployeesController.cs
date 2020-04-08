using FirstApplication.Repositry;
using FirstApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace FirstApplication.Controllers{

  public class EmployeesController:Controller
  {
     private readonly IRepositry<Employees,int> _repo;
        private IWebHostEnvironment Environment;
      public EmployeesController(IRepositry<Employees,int> repo,IWebHostEnvironment _environment)
      {
          
          this._repo = repo;
          this.Environment =_environment;
      }

      public IActionResult Index(){

          return View(this._repo.GetAll());
      }
      public IActionResult Create(){
          return View();
      }
      [HttpPost]
      public IActionResult Create(Employees employees){

          if(ModelState.IsValid){
              if(employees.myfile != null){
            
            string filePath = Path.Combine(this.Environment.WebRootPath,"images",Guid.NewGuid().ToString()+Path.GetExtension(employees.myfile.FileName));
            FileStream stream =  new FileStream(filePath,FileMode.CreateNew);
            employees.myfile.CopyTo(stream);
              }
              this._repo.Insert(employees);
              return RedirectToAction("Index");

          }

          return View();

      }

      public IActionResult Details(int? ID){
          
          if(ID == null){
              return BadRequest();
          }
          Employees employees =  _repo.GetByID(async=>async.ID == ID);
          if(employees == null){
              return NotFound();
          }
         
            return View(employees);

      }
     
      public IActionResult Delete(int? ID){
          if(ID == null){
              return BadRequest();

          }
       Employees employees =  _repo.GetByID(async=>async.ID == ID);
       if(employees == null){
           return NotFound();
       }
         _repo.Delete(async=>async.ID == ID);

        return RedirectToAction("Index");
         
      }

      public IActionResult Edit(int? ID){
          if(ID == null){
              return BadRequest();
          }
          Employees employees = _repo.GetByID(async=>async.ID ==ID);
          if(employees == null){
              return NotFound();
          }
          return View(employees);
      }



     [HttpPost]
    public IActionResult Edit(Employees employees){
    
       if(ModelState.IsValid){
           Employees employees1 =  _repo.GetByID(async=>async.ID == employees.ID);
           employees1.Name = employees.Name;
           employees1.Salary = employees1.Salary;
           return RedirectToAction("Index");
       }

          
          return View(employees);
      }



      


      
  }
   

}