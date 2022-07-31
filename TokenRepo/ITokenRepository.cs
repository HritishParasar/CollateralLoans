using AuthorizationService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.TokenRepo
{
    public interface ITokenRepository
    {
        public string CreateJWT(IConfiguration config, LoginModel member);
    }
}
