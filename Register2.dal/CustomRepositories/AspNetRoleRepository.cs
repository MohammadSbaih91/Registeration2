
using DAL;
using DAL.Repositories;
using Register2.dal.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CyberResilience.DAL.CustomRepositories
{
    public class AspNetRoleRepository : Repository<AspNetRole>
    {
        public AspNetRoleRepository(UnitOfWork uow) : base(uow) { }

        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;


            roles = GetQuerable(u => u.AspNetUsers.Any(x => x.UserName == userName)).Select(x => x.Name)
                   .ToList();
            return roles;
        }

    }
}
