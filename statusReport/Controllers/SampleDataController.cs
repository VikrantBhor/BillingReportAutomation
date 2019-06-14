using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

      //  [HttpGet("[action]")]
        public IEnumerable<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            projects.Add(new Project { projectName = "Tests1", customerName = "Test1" });
            projects.Add(new Project { projectName = "Tests2", customerName = "Test2" });
            projects.Add(new Project { projectName = "Tests3", customerName = "Test3" });

            return projects;
        }



        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        public class Project
        {
            public string projectName { get; set; }

            public string customerName { get; set; }
        }
    }
}
