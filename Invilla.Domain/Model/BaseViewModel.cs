using System;

namespace Invilla.Domain.Model
{
    public class BaseViewModel
    {

        public long? Id { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string? Message { get; set; }
        

    }
}
