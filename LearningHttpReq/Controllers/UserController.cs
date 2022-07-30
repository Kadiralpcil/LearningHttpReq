using LearningHttpReq.Fake;
using LearningHttpReq.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningHttpReq.Controllers
{
    [ Route("api/[controller]")]
    public class UserController : Controller
    {
        private List<User> _users = FakeData.GetUsers(20);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(f => f.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;

            return user;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(f => f.Id == id);
            _users.Remove(deletedUser);
            
        }
    }
}
