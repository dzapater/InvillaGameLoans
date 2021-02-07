using System;
using System.ComponentModel.DataAnnotations;

namespace Invilla.Domain.Entity
{
    public class LoansEntity : BaseEntity
    {
        public DateTime LoanDateBegin { get; set; }

        public DateTime? LoanDateEnd { get; set; }

        public long IdFriend { get; set; }
        public virtual FriendsEntity Friend { get; set; }

        public long IdGames { get; set; }
        public virtual GamesEntity Game { get; set; }


    }
}
