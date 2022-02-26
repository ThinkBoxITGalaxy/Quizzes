using Microsoft.AspNetCore.Mvc;
using Quizzes.APIcommunicate;
using Quizzes.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;
using QuizLibrary;

namespace Quizzes.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("Load");
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
        [HttpPost("action"), Route("/Subjects")]
        public IActionResult Subjects()
        {
            return View();
        }

        //=============================================

        [HttpPost("action"), Route("/Load")]
        public IActionResult Load()
        {
            try
            {
                JavaScriptSerializer seria = new JavaScriptSerializer();
                List<TeachersModel> pl = seria.Deserialize<List<TeachersModel>>(new WebCaller().WebCall("/api/GetTest"));
                if (pl == null)
                {
                    return View("Error");
                }
                else
                return View("Begin", pl);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost("action"), Route("GetStudies")]
        public IActionResult GetStudies()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Studies> st = ser.Deserialize<List<Studies>>(new WebCaller().WebCall("/api/GetStudies"));

             
            if (st == null)
            {
                return View("Error");
            }
            else
                return View("Quiz", st);

        }
        [HttpPost("action"), Route("GetSubjects")]
        public IActionResult GetSubjects([FromForm] SubjectView sv)
        {
            string st = new WebCaller().Getdata("/api/GetSubjects", new JavaScriptSerializer().Serialize(sv));
            List<SubjectView> pa = new JavaScriptSerializer().Deserialize<List<SubjectView>>(st);

            return View("Subjects", pa);
        }

        //[HttpPost("action"), Route("/GetTeacher")]
        //public IActionResult GetTeacher()
        //{
        //    var TeacherData = dao.GetTeachers();
        //    return View("Begin", TeacherData);
        //}
        //[HttpPost("action"), Route("/Studies")]
        //public IActionResult Studies()
        //{
        //    var StudiesData = new Tuple<List<Studies>>(dao.GetStudies());
        //    return View("Quiz", StudiesData);
        //}
      
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