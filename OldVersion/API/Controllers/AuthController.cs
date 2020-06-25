using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//using API.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // [AllowAnonymous]
        // [HttpPost("login")]
        // public async Task<ActionResult<User>> Login()
        // {

        // }

        // [AllowAnonymous]
        // [HttpPost("register")]
        // public async Task<ActionResult<User>> Register()
        // {
        // }

        // [HttpGet]
        // public async Task<ActionResult<User>> CurrentUser()
        // {
        // }
    }
}