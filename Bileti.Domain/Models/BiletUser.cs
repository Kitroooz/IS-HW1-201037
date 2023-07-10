using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bileti.Domain.Models
{
    public class BiletUser : IdentityUser
    {
        
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }

            public virtual ShoppingCart UserCart { get; set; }
        
    }
}
