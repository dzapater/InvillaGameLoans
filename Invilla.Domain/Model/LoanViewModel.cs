using System;

namespace Invilla.Domain.Model
{
    public class LoanViewModel : BaseViewModel
    {

        public DateTime? LoanDateBegin { get; set; }

        public DateTime? LoanDateEnd { get; set; }

        public int?[] IdFriend { get; set; }
        
        public int?[] IdGame { get; set; }

        public string? Friend { get; set; }

        public string? Game { get; set; }

    }
}
