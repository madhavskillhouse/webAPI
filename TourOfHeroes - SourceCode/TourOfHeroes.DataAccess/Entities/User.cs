using System;
using System.Collections.Generic;

#nullable disable

namespace TourOfHeroes.DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Heroes = new HashSet<Hero>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Passsword { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
