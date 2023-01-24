using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using PortofiloProject.Data;
using PortofiloProject.Models;
using PortofiloProject.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PortofiloProject.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {

        private readonly PortfoiloDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;

        public ProjectController(PortfoiloDbContext postDbContext, IHostEnvironment hostEnvironment)
        {
            _context = postDbContext;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Project> projects = _context.projects.ToList();

            return View(projects);

        }
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == "ruba" && password == "123")
            {

                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));

                // claimIdentity
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // claimPrincipal 
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimPrincipal);

                return RedirectToAction(nameof(Index));

            }
            else
            {
                return BadRequest();
            }
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
            Console.WriteLine(_hostEnvironment.ContentRootPath);
            var uploadFolder = Path.Combine("wwwroot/", "Photos");
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



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var project = _context.projects.Where(s => s.Id == Id).FirstOrDefault();
            return View(project);
        }




        [HttpPost]
        public IActionResult Edit(Project project)
        {
           

            if (ModelState.IsValid)
            {

                _context.Update(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }


        public IActionResult Details(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var project = _context.projects.FirstOrDefault(m => m.Id == Id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

  
    

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var post = _context.projects
              .FirstOrDefault(m => m.Id == Id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [HttpPost]
        public IActionResult Delete(int Id )
        {
            var project = _context.projects.Find(Id);
            var imagePath = Path.Combine("wwwroot/", "Photos", project.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _context.projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}

