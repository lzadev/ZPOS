using Microsoft.AspNetCore.Identity;

namespace ZPOS.UI.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
