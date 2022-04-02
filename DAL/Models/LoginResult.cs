using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LoginResult
    {
        public JwtSecurityToken Token { get; set; }
        public string UserId { get; set; }
    }
}
