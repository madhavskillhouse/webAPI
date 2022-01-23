using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.DataAccess;
using TourOfHeroes.DataAccess.Entities;
using TourOfHeroes.Models;

namespace TourOfHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        public UserController()
        {
            this.userRepository = new UserRepository();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create (UserModel user)
        {
            await userRepository.Create(new User
            {
                UserName = user.UserName,
                Passsword = user.Passsword
            });
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = userRepository.GetByCredentials(loginModel.UserName, loginModel.Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}