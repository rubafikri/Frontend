namespace PortofiloProject.ViewModels
{
    public class AddProjectVM
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public IFormFile Image { get; set; }
    }
}
