using System.Collections.Generic;

namespace Invilla.Domain.Entity
{
    public class GamesEntity : BaseEntity
    {
        public string FullGameName { get; set; }

        public bool Loaned { get; set; }

        public virtual ICollection<LoansEntity> LoansGames { get; set; }

    }
}
