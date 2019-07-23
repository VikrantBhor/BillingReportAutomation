using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using statusReport.Common;

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly AllowedUsers _allowedUsers;
        private readonly ManagerSettings _managerSettings;

        public UsersController(IOptions<AllowedUsers> allowedUsers, IOptions<ManagerSettings> managerSettings)
        {
            _allowedUsers = allowedUsers.Value;
            _managerSettings = managerSettings.Value;
        }

        [HttpGet]
        [Route("allowedUsers")]
        public IActionResult Get()
        {
            return Ok(_allowedUsers);
        }

        [HttpGet]
        [Route("manager")]
        public IActionResult GetFinanceManager()
        {
            return Ok(_managerSettings);
        }
    }
}