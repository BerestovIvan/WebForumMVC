using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class LoginResultModel
    {
        public JwtSecurityToken Token { get; set; }
        public string UserId { get; set; }
    }
}
