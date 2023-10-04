using Application.Services.Interfaces;
using Domain.DTOs.Account.User;
using Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Api.Controllers
{
    public class UserController : BaseSiteController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //  return  Ok(await _userService.GetAllUserInformationAsync());
            var users = await _userService.GetAllUserInformationAsync();
            return Ok(users);


        }

        // GET api/<UserController>/5
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            return Ok(await _userService.GetUserInformationAsync(userName));     
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
