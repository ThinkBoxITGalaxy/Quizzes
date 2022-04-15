using Microsoft.AspNetCore.Mvc;
using QuizLibrary;
using Quizzes.APIcommunicate;
using Quizzes.Models;
using System.Diagnostics;
using System.Web.Script.Serialization;


namespace Quizzes.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Login");
            //return View();
            //return RedirectToAction("Load");
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
        [HttpPost("action"), Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("action"), Route("InsertStud")]
        public IActionResult InsertStud()
        {
            return View();
        }
        //=============================================

        //[HttpPost("action"), Route("/AccountLogin")]
        //public IActionResult AccountLogin()
        //{
        //    try {
        //        JavaScriptSerializer sr = new JavaScriptSerializer();
        //        List<LoginModel> lm = sr.Deserialize<List<LoginModel>>(new WebCaller().WebCall(""));
        //    }
        //}

        [HttpGet("action"), Route("/Load")]
        public IActionResult Load()
        {
            try
            {
                JavaScriptSerializer seria = new JavaScriptSerializer();
                List<TeachersModel> pl = seria.Deserialize<List<TeachersModel>>(new WebCaller().WebCall("/api/GetTeacher"));
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
        [HttpPost("action"), Route("GetAllTeacher")]
        public IActionResult GetAllTeacher()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<TeachersModel> st = ser.Deserialize<List<TeachersModel>>(new WebCaller().WebCall("/api/GetTeacher"));
            if (st == null)
                return View("Error");
            else
                return View("InsertStud", st);
        }
        [HttpPost("action"), Route("GetSubjects")]
        public IActionResult GetSubjects([FromForm] SubjectView sv)
        {
            string st = new WebCaller().Getdata("/api/GetSubjects", new JavaScriptSerializer().Serialize(sv));
            List<SubjectView> pa = new JavaScriptSerializer().Deserialize<List<SubjectView>>(st);

            return View("Subjects", pa);
        }
        [HttpPost("action"), Route("GetLogin")]
        public IActionResult GetLogin([FromForm] LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                string va = new WebCaller().Getdata("/api/GetLogin", new JavaScriptSerializer().Serialize(lm));
                List<LoginModel> lo = new JavaScriptSerializer().Deserialize<List<LoginModel>>(va);
                if (lo.Count != 0)
                {
                    return RedirectToAction("Load");
                }
                else
                    return View("Login");
            }
            else
                return View("Login");
        }
        [HttpPost("action"), Route("CreateTeacher")]
        public IActionResult CreateTeacher(TeachersModel tm)
        {
            WebCaller caller = new WebCaller();
            caller.InsertData("/api/CreateTeacher", new JavaScriptSerializer().Serialize(tm));
            return RedirectToAction("GetAllTeacher");
        }
     
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

//1. Add Students
//2. Edit Students
//3. Delete Students
