using BikeRental.Data;
using BikeRental.Data;
using BikeRental.Data.Model;
using BikeRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.Controllers
{
    public class BikeController : Controller
    {
        public class StudentController : Controller
        {
            private readonly ApplicationDbContext db;
            private readonly IWebHostEnvironment webHostEnvironment;
           // private readonly IKlassService service;

            public StudentController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment
                //, IKlassService service
               
                )
            {
                this.db = db;
                this.webHostEnvironment = webHostEnvironment;
                //this.service = service;
            }
            public IActionResult Add()
            {
                var model = new BikeViewModel();
            //    model.Price = service.GetKlasses();
                return View(model);
            }
            [HttpPost]
            public async Task<IActionResult> Add(BikeViewModel model)
            {
                var student = new Bike
                {
                    Id = model.BikeId,
                    Brand = model.Brand,
                    Category = model.Category
                };
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid().ToString();
                var physicalPath = $"{this.webHostEnvironment.WebRootPath}/img/{fileName}.{extension}";
                using (FileStream fs = new FileStream(physicalPath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fs);
                };
                student.ImageName = fileName;
                student.ImageExtension = extension;


                db.Bikes.Add(student);
                db.SaveChanges();
                return Redirect("Index");
            }
            public IActionResult Index()
            {
                List<BikeViewModel> model = db.Bikes.Select(x => new BikeViewModel
                {
                    BikeId = x.Id,
                    Model=x.Model,
                    Brand=x.Brand,
                    Category=x.Category,
                    Price=x.Price,
                    ImageURL = $"/img/{x.ImageName}.{x.ImageExtension}"
                }).ToList();

                return View(model);
            }
            public IActionResult Details(int id)
            {
                var model = db.Bikes.Where(x => id == x.Id).Select(s => new BikeViewModel
                {
                   Model=s.Model,
                    Category = s.Category,
                    ImageURL = $"/img/{s.ImageName}.{s.ImageExtension}"
                }).FirstOrDefault();

                return View(model);

            }
        }
    }
}
