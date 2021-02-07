using System;

namespace Invilla.Domain.Model
{
    public class LoginViewModel : BaseViewModel
    {
        public string FullName { get; set; }

        public string Password { get; set; }

        public long IdRole { get; set; }

    }
}
