using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortofiloProject.Data;
using PortofiloProject.Models;
using PortofiloProject.ViewModels;
using System.Net;

namespace PortofiloProject.Controllers
{
    public class PostController : Controller
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


        public IActionResult View(int Id)
        {
            if(Id == null)
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





    }
}
