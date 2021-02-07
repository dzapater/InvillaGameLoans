namespace Invilla.Domain.Entity
{
    public class LoginsEntity : BaseEntity
    {

        public string FullName { get; set; }

        public string Password { get; set; }
        
        public long IdRole { get; set; }
        public virtual RolesEntity Role { get; set; }

        public string Token { get; set; }


    }
}
