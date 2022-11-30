using Register.BLL.UsersBusinessLogic;
using Registeration2.Common.DTO_s.UsersDTO;
using Registeration2.Common.DTOs.UsersDTO;
using Registration2.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Registeration2.Controllers
{
    //[Authorize]
    public class UserController : BaseController
    {
        public UsersBusinessLogic _UserBusinessLogic;

        public UserController()
        {
            _UserBusinessLogic = new UsersBusinessLogic();
        }
        public async Task<ActionResult> Students()
        {

            List<AspNetUserDTO> studentslist = new List<AspNetUserDTO>();
            studentslist = _UserBusinessLogic.GetStudents();
            return View(studentslist);


        }

        public async Task<ActionResult> StudentsList()
        {

            List<UsersDTO> studentslist = new List<UsersDTO>();
            studentslist = _UserBusinessLogic.GetStudentsList();
            return View(studentslist);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(UsersDTO userDto)
        {
            //userDto.AspNetUserId = base.GetCurrentUser().Id;
            var isCreated = _UserBusinessLogic.CreateStudent(userDto);

            if (isCreated == true)
            {
                return Redirect("CreateStudent");
            }
            else
            {
                return Redirect("CreateStudent");
            }
        }


        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegisterStudent(UsersDTO userDTO)
        {
            userDTO.AspNetUserId = base.GetCurrentUser().Id;
            bool isRegistered = _UserBusinessLogic.RegisterStudent(userDTO);

            if(isRegistered == true)
            {
                return Redirect("RegisterStudent");
            }
            else
            {
                return Redirect("RegisterStudent");
            }
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var user = new UsersDTO();
            user = _UserBusinessLogic.GetUserById(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateStudent(UsersDTO userDTO)
        {
            var isUpdated = _UserBusinessLogic.UpdateStudent(userDTO);

            if(isUpdated == true)
            {
                return RedirectToAction("UpdateStudent", new { id = userDTO.Id });
            }
            else
            {
                return RedirectToAction("UpdateStudent", new { id = userDTO.Id });
            }
            

        }
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var isDeleted = _UserBusinessLogic.DeleteStudent(id);

            if(isDeleted == true)
            {
                return Redirect("StudentsList");
            }
            else
            {
                return Redirect("StudentsList");
            }
        }
    }
}