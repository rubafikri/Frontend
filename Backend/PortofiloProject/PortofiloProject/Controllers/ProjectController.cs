using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PortofiloProject.Data;
using PortofiloProject.Models;
using PortofiloProject.ViewModels;



namespace PortofiloProject.Controllers
{
    public class ProjectController : Controller
    {

        private readonly PortfoiloDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProjectController(PortfoiloDbContext postDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Project> projects = _context.projects.ToList();

            return View(projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddProjectVM addProjectVM = new AddProjectVM();
            return View(addProjectVM);
        }


        [HttpPost]
        public IActionResult Add(AddProjectVM addProjectVM)
        {
            var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Photos");
            string uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(path: addProjectVM.Image.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueName);
            addProjectVM.Image.CopyTo(new FileStream(filePath, FileMode.Create));


            _context.projects.Add(new Project
            {
                Title = addProjectVM.Title,
                Body = addProjectVM.Body,
                ImageName = uniqueName
            });
            _context.SaveChanges();

           
            return RedirectToAction(nameof(Index));
            //return View();
        }


    }
}
