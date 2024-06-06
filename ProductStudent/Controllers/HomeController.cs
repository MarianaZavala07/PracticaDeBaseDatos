using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductStudent.Entities;
using ProductStudent.Models;

namespace ProductStudent.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {

        Students estudiante = new Students();
        estudiante.name = "Mario";
        estudiante.Id = new Guid();
        estudiante.Tetra = 7;
        estudiante.LastName = "Aguirre";

        this._context.Students.Add(estudiante);
        this._context.SaveChanges();
        return View();
    }

    public IActionResult Privacy()
    {
        //para insertar
        //Students estudiante = new Students();
        //estudiante.name = "Carlos";
        //estudiante.Id = new Guid();
        //estudiante.Tetra = 5;
        //estudiante.LastName = "Marin";

        //this._context.Students.Add(estudiante);
        //this._context.SaveChanges();
        
        //para Actualizar
        //Students estudianteActualiza = this._context.Students
        //.Where(c => c.Id==new Guid("2763454D-64AA-40C4-5647-08DC85007CF8"))
        //.First();
       // estudianteActualiza.name="Veronica";
       // estudianteActualiza.LastName="Torres";
        //this._context.Students.Update(estudianteActualiza);
       // this._context.SaveChanges();
          //borrar registro
        //Students estudianteBorrado = this._context.Students
        //.Where(c =>c.Id==new Guid("2763454D-64AA-40C4-5647-08DC85007CF8"))
        //.First();
        //this._context.Students.Remove(estudianteBorrado);
        //this._context.SaveChanges();
        
         List<StudentsModel> list = new List<StudentsModel>();
         list = _context.Students.Select(s => new StudentsModel()
         {
            Id = s.Id,
            name=s.name,
            LastName=s.LastName,
            Tetra=s.Tetra,
         }).ToList();
         
        
        
        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
