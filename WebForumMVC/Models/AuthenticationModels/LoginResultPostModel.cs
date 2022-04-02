using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumMVC.Models.AuthenticationModels
{
    public class LoginResultPostModel
    {
        public JwtSecurityToken Token { get; set; }
        public string UserId { get; set; }
    }
}
