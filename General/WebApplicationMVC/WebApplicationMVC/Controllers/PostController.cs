using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class PostController : Controller
    {
        private static List<Post> posts = new List<Post>();
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.PostList = posts;
            return View();
        }

        [HttpPost]
        public IActionResult Add(string title)
        {
            posts.Add(new Post { Title = title });
            return RedirectToAction(nameof(Add));
        }
    }
    public class Post
    {
        public string Title { get; set; }
    }
}
