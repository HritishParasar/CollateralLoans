using AuthorizationService.Models;
using AuthorizationService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.MemberRepo
{
    public class MemberRepository : IMemberRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EmployeeDbContext _employeeDb;
        public MemberRepository(EmployeeDbContext employeeDb)
        {
            _employeeDb = employeeDb;
        }

        //Checks whether the UserName and Password present in database or not
        public LoginModel GetMember(LoginModel model)
        {
            log.Debug("Trying to Get Member with the given Credentials");
            LoginModel employee = _employeeDb.Employees.SingleOrDefault(e => e.UserName==model.UserName && e.Password==model.Password);
            return employee;
        }
    }
}
