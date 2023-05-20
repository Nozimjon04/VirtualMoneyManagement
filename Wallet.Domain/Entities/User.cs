using UserWebApi.UserWebApi.Domain.Commons;


namespace UserWebApi.UserWebApi.Domain.Models
{
    public class User : Auditable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
