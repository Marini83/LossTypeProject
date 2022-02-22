using LossTypeProject.Server.Interfaces;
using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace LossTypeProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Task.FromResult(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _userService.GetUserData(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(User user)
        {
            _userService.AddUser(user);
        }

        [HttpPut]
        public void Put(User user)
        {
            _userService.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
