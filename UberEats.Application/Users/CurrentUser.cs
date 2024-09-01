using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Application.Users
{
    public record CurrentUser(string Id,string Email,IEnumerable<string>Roles)
    {
        public bool IsInRole(string RoleName) =>Roles.Contains(RoleName);
    }
}
