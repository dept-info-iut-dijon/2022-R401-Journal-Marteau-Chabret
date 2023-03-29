using Diary.Data;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiariesController : Controller
    {
        // Représente le dao pour accéder aux données
        private DiaryDao diaryDao = new DiaryDao(new Database());

        [HttpGet("testBdd")]
        public IActionResult TestBDD()
        {
            Database d = new Database();
            return new JsonResult(d.TestConnection());
        }

        [HttpGet("{id}")]
        public IActionResult ReadDiary(string id)
        {
            try
            {
                
                return new JsonResult(this.diaryDao.Read(new LogicLayer.User() { Id = Convert.ToInt32(id) }));
            }
            catch (Exception ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
        }


        [HttpPost("entry")]
        public IActionResult InsertEntry(Entry entry)
        {
            try
            {
                this.diaryDao.AddEntry(entry);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            
        }

        [HttpGet("categories")]
        public IActionResult ReadCategories()
        {
           return new NotFoundResult();
        }
    }
}
