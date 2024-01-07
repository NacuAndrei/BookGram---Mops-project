﻿using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager userManager)
        {
            this.manager = userManager;
        }

        //get all users
        [HttpGet("Get_All_Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = manager.GetUsers();
            return Ok(users);
        }

        [HttpDelete("Delete_User_By_{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            manager.DeleteUser(id);
            return Ok();
        }

    }
}