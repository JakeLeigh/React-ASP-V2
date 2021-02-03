using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCrudApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil" };
        private static readonly string[] surnames = new string[] { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser" };
        private static readonly string[] extensions = new string[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com" };
        static UsersController()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                User user = new User
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+1 888-452-1232"
                };
                users.Add(user);
            }
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public IEnumerable<User> Get(int id)
        {
            yield return users.Where(user => user.Id == id).FirstOrDefault();
        }
        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            user.Id = Count++;
            users.Add(user);
            return (IActionResult)user;
        }
        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            User found = users.Where(n => n.Id == id).FirstOrDefault();
            found.Name = user.Name;
            found.Email = user.Email;
            found.Document = user.Document;
            found.Phone = user.Phone;
            return NoContent();
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            users.RemoveAll(n => n.Id == id);
            return NoContent();
        }
        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }
    }
}
