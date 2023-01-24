namespace PortofiloProject.ViewModels
{
    public class AddPostsVM
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Detailes { get; set; }
    }
}
