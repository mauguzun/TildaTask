using Microsoft.AspNetCore.Identity;

namespace SecondTask.Models
{
    public class BankUser : IdentityUser
    {
        public int Amount { get; set; }

        
    }
}
