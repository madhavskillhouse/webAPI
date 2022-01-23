using System;
using System.Collections.Generic;

#nullable disable

namespace TourOfHeroes.DataAccess.Entities
{
    public partial class Hero
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
