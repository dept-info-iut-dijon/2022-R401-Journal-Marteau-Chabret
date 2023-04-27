using Diary.Data;
using LogicLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    /// <summary>
    /// Controller du journal
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DiariesController : Controller
    {
        // Représente les dao pour accéder aux données
        private DiaryDao diaryDao = new DiaryDao(new Database());
        private CategoryDao categoryDao = new CategoryDao(new Database());
        private UserDao userDao = new UserDao(new Database());

        /// <summary>
        /// Teste la connexion avec la base de donnée
        /// </summary>
        /// <returns></returns>
        [HttpGet("testBdd")]
        public IActionResult TestBDD()
        {
            Database d = new Database();
            return new JsonResult(d.TestConnection());
        }

        /// <summary>
        /// Lit un journal
        /// </summary>
        /// <param name="id"> id de l'utilisateur auquel appartient le journal </param>
        /// <returns> le résultat de l'action </returns>
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


        /// <summary>
        /// Insert une nouvelle entrée au journal
        /// </summary>
        /// <param name="entry"> Entrée à ajouter </param>
        /// <returns> Résultat de l'action </returns>
        [HttpPost("AddEntry")]
        public IActionResult InsertEntry(Entry entry)
        {
            try
            {
                this.diaryDao.AddEntry(entry);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
            
        }

        /// <summary>
        /// Récupère toutes les catégories
        /// </summary>
        /// <returns> Résultat de l'action </returns>
        [HttpGet("categories")]
        public IActionResult ReadCategories()
        {
            try
            {
                return new JsonResult(this.categoryDao.GetAllCategories());
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult GetStudent(string login, string password)
        {
            try
            {
                IActionResult actionResult = new ForbidResult();
                Student student = this.userDao.GetStudent(login, password);
                if (student != null)
                {
                    actionResult =  new JsonResult(student);
                }
                return actionResult;
            }
            catch(Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
