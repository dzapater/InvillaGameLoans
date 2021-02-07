using System;
using System.ComponentModel.DataAnnotations;

namespace Invilla.Domain.Entity
{
    public class BaseEntity
    {

        [Key]
        public long Id { get; set; }

        private DateTime? _registrationDate;
        public DateTime? RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = (value == null ? DateTime.Now : value); }
        }

        public DateTime? UpdateDate { get; set; }

    }
}
