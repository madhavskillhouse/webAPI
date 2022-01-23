using System.Collections.Generic;
using System.Threading.Tasks;
using TourOfHeroes.DataAccess.Entities;
using System.Linq;
namespace TourOfHeroes.DataAccess
{
    public class HeroesRepository
    {
        private readonly TourOfHeroesContext dbContext;
        public HeroesRepository()
        {
            this.dbContext = new TourOfHeroesContext();
        }

        public async Task Create(Hero hero)
        {
            dbContext.Heroes.Add(hero);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update (Hero hero)
        {
            var existingHero = dbContext.Heroes.Where(h => h.Id == hero.Id).FirstOrDefault();
            if (existingHero != null)
            {
                existingHero.FullName = hero.FullName; // update only changeable properties
                await this.dbContext.SaveChangesAsync();
            }
        }

        public List<Hero> GetByUser (int userId)
        {
            return dbContext.Heroes.Where(h => h.UserId == userId).ToList();
        }

        public async Task<Hero> GetById (int heroId)
        {
            var hero = await dbContext.Heroes.FindAsync(heroId);
            return hero;
        }

        public async Task Delete (int heroId)
        {
            var hero = await GetById(heroId);
            if (hero != null)
            {
                dbContext.Heroes.Remove(hero);
            }
        }
    }
}
