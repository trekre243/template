using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Template.Models;

namespace Template.Controllers
{
    public class TemplateController : Controller
    {   
        private MyContext dbContext;

        public TemplateController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            //View will defaultly look for a view named "Index" (name of action) in folder named "Template" from the controller name
            return View();
        }

        //route variables are parameters of the action
        [HttpGet("users/{name}/{age}")]
        public ViewResult Name(string name, int age)
        {
            return View();
        }

        [HttpGet("cat")]
        public RedirectToActionResult RedirectSample()
        {
            return RedirectToAction("Name", new {name = "Trevor", age = 32});
        }

        [HttpGet("elsewhere")]
        public IActionResult Elsewhere() //IActionResult allows for redirects or views from the same action
        {
            //To redirect to the action of another controller the name of the controller must be the second argument
            //An anonymous object can also be used as the third parameter if arguments are necessary
            return RedirectToAction("OtherAction", "OtherC"); //for json "return Json(obj)"
        }

        //parameters correspond to field names
        [HttpPost("user")]
        public IActionResult UserCreate(string firstName, string lastName)
        {
            return View();
        }
    }
}
