using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using statusReport.Controllers.Home;

namespace statusReport.Controllers.Home
{
    [EnableCors("AzurePolicy")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("profile")]
        public IActionResult profile()
        {
            var model = new ProfileModel
            {
                Name = User.Identity.Name,
                Claims = User.Claims
            };

            return View(model);

        }




        //public IEnumerable<Project> GetProjects()
        //{
        //    List<Project> projects = new List<Project>();
        //    projects.Add(new Project { projectName = "Tests1", customerName = "Test1" });
        //    projects.Add(new Project { projectName = "Tests2", customerName = "Test2" });
        //    projects.Add(new Project { projectName = "Tests3", customerName = "Test3" });

        //    return projects;
        //}


        //public IActionResult Error() =>
        //    View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    //public class Project
    //{
    //    public string projectName { get; set; }

    //    public string customerName { get; set; }
    //}
}