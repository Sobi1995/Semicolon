
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class User : IdentityUser<int>
    {
        public DateTime Created { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
    }
}
