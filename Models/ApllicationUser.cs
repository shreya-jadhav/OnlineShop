using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models
{
    public class ApllicationUser:IdentityUser
    {
        public  string FirstName { get; set; }
        public string LasttName { get; set; }
    }
}
