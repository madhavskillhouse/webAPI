using System.Threading.Tasks;
using TourOfHeroes.DataAccess.Entities;
using System.Linq;

namespace TourOfHeroes.DataAccess
{
    public class UserRepository
    {
        private readonly TourOfHeroesContext dbContext;
        public UserRepository()
        {
            this.dbContext = new TourOfHeroesContext();
        }

        public async Task Create(User user)
        {
            await dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();
        }

        public User GetByCredentials (string userName, string password)
        {
            var user = dbContext.Users.Where(usr => usr.UserName == userName && usr.Passsword == password).FirstOrDefault();
            return user;
        }
    }
}
