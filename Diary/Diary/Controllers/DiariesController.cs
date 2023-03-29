using Diary.Data;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiariesController : Controller
    {
        [HttpGet]
        public IActionResult TestBDD()
        {
            Database d = new Database();
            return new JsonResult(d.TestConnection());
        }
    }
}
