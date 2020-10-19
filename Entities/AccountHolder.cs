using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ClearSky.Entities
{
    public class AccountHolder:IdentityUser
    {
        // inherits id, username etc from identity user package so no need to ovveride
        public ICollection<Message> Messages { get; set; } 
        // single user has many messages
        public AccountHolder(){
            this.Messages = new List<Message>();
        }
    }
}