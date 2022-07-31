using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.MemberRepo
{
    public interface IMemberRepository
    {
        LoginModel GetMember(LoginModel model);
    }
}
