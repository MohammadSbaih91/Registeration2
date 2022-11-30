using Registeration2.Common.DTOs.UsersDTO;
using Register2.dal;
using Registeration2.Common.DTO_s.UsersDTO;
using DAL;

namespace Registeration2.BLL.UsersBusinessLogic
{
    public class AspNetUserBusinessLogic
    {

        public string RegisterUser(UsersDTO user)
        {
            using (var uow = new UnitOfWork())
            {
                //string UserId = uow.AspNetUsers.RegisterUser(user);
                //return UserId;
                return "ss";
            }
        }


        public AspNetUserDTO GetUserByName(string userName)
        {
            using (var uow = new DAL.UnitOfWork())
            {

                var userEntity = uow.AspNetUsers.GetUserByName(userName);
                var user = new AspNetUserDTO()
                {
                    Id = userEntity.Id,
                    UserName = userEntity.UserName,
                    Email = userEntity.Email,
                    EmailConfirmed = userEntity.EmailConfirmed,
                    AccessFailedCount = userEntity.AccessFailedCount,
                };
                return user;
            }
        }

    }
}
