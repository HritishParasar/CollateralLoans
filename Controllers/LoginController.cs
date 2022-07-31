using AuthorizationService.MemberRepo;
using AuthorizationService.Models;
using AuthorizationService.TokenRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors]
    public class LoginController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IConfiguration _config;
        private readonly ITokenRepository _repository;
        private readonly IMemberRepository _memberRepository;
        public LoginController(ITokenRepository repository, IMemberRepository memberRepository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
            _memberRepository = memberRepository;
        }

        //Checks the credentials are valid or not if valid it will produce a JWT Token
        //Else shows the status as 0 which is not successfull
 
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            log.Debug("Entered Controller to Authenticate");
            try
            {
                LoginModel member = _memberRepository.GetMember(model);
                if (member != null)
                {
                    var tokenString = _repository.CreateJWT(_config, member);
                    return Ok(new Result { Status=1,Token=tokenString } );
                }
                return Ok(new Result { Status = 0, Token = "" });
            }
            catch (Exception e)
            {
                log.Debug("Exception Occured While Trying to Authenticate"+e);

                return BadRequest(new Result { Status = 0, Token = "" });
            }
        }
        }
}
