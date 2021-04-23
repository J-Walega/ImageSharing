using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageSharing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            return NotFound();
        }

        [HttpPost]
        public ActionResult <User> Register()
        {
            return NotFound();
        }
    }
}
