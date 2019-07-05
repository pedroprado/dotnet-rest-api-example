using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web_api_example.Models;
using web_api_example.Repository;

namespace web_api_example.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController()
        {
            //this._userRepository = userRepository;
        }

        [HttpGet("get/all")]
        public IActionResult getUsers(){
            var lista = new List<User>{
                new User(1,"um","um","um"),
                new User(2,"dois","dois","dois")
            };
            return new ObjectResult( lista);
            //return _userRepository.getAllUsers();
        }

        [HttpGet("{id}")]
        public IActionResult getUserById(int id){
            return new ObjectResult(new User(11,"a","a","a"));
            //return _userRepository.getUserById(id);
        }
    }
}