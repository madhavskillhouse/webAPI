using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.DataAccess;
using TourOfHeroes.DataAccess.Entities;
using TourOfHeroes.Models;

namespace TourOfHeroes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroesRepository heroesRepository;
        public HeroController()
        {
            heroesRepository = new HeroesRepository();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(HeroModel hero)
        {
            await heroesRepository.Create(new Hero
            {
                FullName = hero.FullName,
                UserId = hero.UserId
            });
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(HeroModel hero)
        {
            await heroesRepository.Update(new Hero
            {
                FullName = hero.FullName
            });
            return Ok();
        }

        [HttpGet("GetByUser/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var heroes = heroesRepository.GetByUser(userId);
            return Ok(heroes);
        }

        [HttpGet("GetById/{heroId}")]
        public async Task<IActionResult> GetById(int heroId)
        {
            var heroes = await heroesRepository.GetById(heroId);
            return Ok(heroes);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int heroId)
        {
            await heroesRepository.Delete(heroId);
            return Ok();
        }
    }
}