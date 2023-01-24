using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortofiloProject.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {

    }
}
