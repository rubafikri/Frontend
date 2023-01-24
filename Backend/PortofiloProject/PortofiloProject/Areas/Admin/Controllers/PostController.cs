using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortofiloProject.Data;
using PortofiloProject.Models;
using PortofiloProject.ViewModels;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PortofiloProject.Areas.Admin.Controllers
{
    
    public class PostController : AdminBaseController
    {
        private readonly PortfoiloDbContext _context;

        public PostController(PortfoiloDbContext postDbContext)
        {
            _context = postDbContext;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.posts.ToList();

            return View(posts);

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
            AddPostsVM addPostsVM = new AddPostsVM();
            return View(addPostsVM);
        }

        [HttpPost]
        public IActionResult Add(AddPostsVM addPostsVM)
        {
            _context.posts.Add(new Post
            {
                Title = addPostsVM.Title,
                Detailes = addPostsVM.Detailes,
                CreatedAt = addPostsVM.CreatedAt
            });
            _context.SaveChanges();
            return RedirectToAction("Index");


        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var post = _context.posts.Where(s => s.Id == Id).FirstOrDefault();
            return View(post);
        }




        [HttpPost]
        public IActionResult Edit( Post postData)
        {
            if (ModelState.IsValid)
            {
          
                _context.Update(postData);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(postData);
        }



        public IActionResult Details(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var post = _context.posts.FirstOrDefault(m => m.Id == Id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

       
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var post =  _context.posts
              .FirstOrDefault(m => m.Id == Id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var post =  _context.posts.Find(Id);
            _context.posts.Remove(post);
             _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}

