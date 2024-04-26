using KinapoiskiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Davaleba.Controllers
{
    public class AccountController : ApiController
    {
        private readonly KinoModel _context;

        public AccountController()
        {
            _context = new KinoModel();
        }

        public IHttpActionResult Register([FromBody]User u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                name = u.name,
                password = u.password 
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully");
        }

        public IHttpActionResult Login([FromBody]User u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.FirstOrDefault(i => i.name == u.name);

            if (user == null || user.password != u.password)
                return Unauthorized();

            return Ok("Login successful");
        }
    }
}
