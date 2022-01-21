using Microsoft.AspNetCore.Mvc;
using Quizzes.Context;
using Quizzes.DataAccessObject;
using Quizzes.Models;
using System.Diagnostics;

namespace Quizzes.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAO dao;

        public HomeController(Cont c)
        {
            dao = new DAO(c);
        }

        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("GetTeacher");
        }

        [HttpPost("action"), Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("action"), Route("/Begin")]
        public IActionResult Begin()
        {
            return View();
        }
        [HttpPost("action"), Route("/Quiz")]
        public IActionResult Quiz()
        {
            return View();
        }

        //=============================================
        [HttpPost("action"), Route("/GetTeacher")]
        public IActionResult GetTeacher()
        {
            var TeacherData = dao.GetTeachers();
            return View("Begin", TeacherData);
        }
        [HttpPost("action"), Route("/Studies")]
        public IActionResult Studies()
        {
            var StudiesData = new Tuple<List<Studies>>(dao.GetStudies());
            return View("Quiz", StudiesData);
        }
        [HttpPost("action"), Route("/Subjects")]
        public IActionResult Subjects([FromForm] SubjectView sv)
        {
            var SubjectViewData = dao.GetSubjectViews(sv.sname);
            return View(SubjectViewData);
        }
        [HttpPost("action"), Route("/Questions")]
        public IActionResult Questions()
        {
            return View();
        }
        
        //=============================================
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//sql add loop data
//DECLARE @idx int 
//SET @idx=1
//WHILE ( @idx <= 10)
//BEGIN
//     Insert Into testtable(id, author, country) values('id-' + CONVERT(VARCHAR, @idx), 'author-' + +CONVERT(VARCHAR, @idx), 'country-' + +CONVERT(VARCHAR, @idx))
//    SET @idx = @idx + 1
//END