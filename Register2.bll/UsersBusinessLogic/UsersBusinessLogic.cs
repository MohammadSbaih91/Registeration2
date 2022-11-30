using System.Collections.Generic;
using Registeration2.Common.DTO_s.UsersDTO;
using Registeration2.Common.DTOs.UsersDTO;

namespace Register.BLL.UsersBusinessLogic
{
    public class UsersBusinessLogic
    {
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
        public List<AspNetUserDTO> GetStudents()
        {
            using (var uow = new DAL.UnitOfWork())
            {

                var usersDto = uow.AspNetUsers.GetStudents();

                return usersDto;
            }
        }
        // you can't creat user using the username you need to creat user using the dto which is already filled by the post action 
        // يعني زي ما شرحنا في الصور لما ترسم ال html وتكون حاط الموديل من نوع aspuserdto 
        // وتكبس على كبسة ال submit ال
        // compiler رح يربط بين ال الصفحة (الفورم) والاكشن الي من نوع post 
        public bool CreateStudent(UsersDTO userDto)
        {
            using (var uow = new DAL.UnitOfWork())
            {

                var userEntitycreatedSuccessfully = uow.Students.CreateStudent(userDto);
                if (userEntitycreatedSuccessfully == true)
                {
                    return true;
                }
                return false;
            }
        }

        public UsersDTO GetUserById(int id)
        {
            using (var uow = new DAL.UnitOfWork())
            {

                var usersDto = uow.Students.GetUserById(id);

                return usersDto;
            }
        }

        public bool UpdateStudent(UsersDTO userDto)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                var userEntityupdatedSuccessfully = uow.Students.UpdateStudent(userDto);
                if (userEntityupdatedSuccessfully == true)
                {
                    return true;
                }
                return false;
            }

        }

        public bool DeleteStudent(int id)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                var userEntityDeletedSuccessfully = uow.Students.DeleteStudent(id);
                if (userEntityDeletedSuccessfully == true)
                {
                    return true;
                }
                return false;
            }
        }

        public bool RegisterStudent(UsersDTO userDTO)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                var userEntityregisteredSuccessfully = uow.Students.RegisterStudent(userDTO);
                if (userEntityregisteredSuccessfully == true)
                {
                    return true;
                }
                return false;
            }
        }
        //public bool IsUserActive(string AspNetUserId)
        //{
        //    using (var uow = new DAL.UnitOfWork())
        //    {
        //        bool isActive = uow.Students.IsUserActive(AspNetUserId);
        //        return isActive;
        //    }
        //}


        public string GetUserIdByUserName(string UserName)
        {

            using (var uow = new DAL.UnitOfWork())
            {
                string UserId = uow.AspNetUsers.GetUserIdByUserName(UserName);
                return UserId;
            }

        }


        public List<UsersDTO> GetStudentsList()
        {
            using (var uow = new DAL.UnitOfWork())
            {

                var usersDto = uow.Students.GetStudentsList();

                return usersDto;
            }
        }


    }
}
