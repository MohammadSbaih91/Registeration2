using Registeration2.BLL.UsersBusinessLogic;
using Registeration2.Common.DTO_s.UsersDTO;
using System.Web.Mvc;

namespace Registration2.Base
{
    public class BaseController : Controller
    {
        public AspNetUserBusinessLogic _AspNetUserBusinessLogic;

        public BaseController()
        {
            _AspNetUserBusinessLogic = new AspNetUserBusinessLogic();
        }
        protected string CurrentUserName
        {
            get
            {
                return User.Identity.Name.Trim().ToLower();
                //var claims = HttpContext.Request.GetOwinContext().Authentication.User.Claims;
                //return claims.Where(x => x.Type == CyberResilience.Common.Constants.Claims.UserName).Single().Value;
            }
        }

        protected AspNetUserDTO GetCurrentUser()
        {
            var user = _AspNetUserBusinessLogic.GetUserByName(CurrentUserName);
            return user;
        }
    }
}