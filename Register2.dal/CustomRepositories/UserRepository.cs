using DAL;
using DAL.Repositories;
using Register.Common.DTOs.UsersDTO;
using Register.Common.Utilities;
using Register2.dal;
using Register2.dal.Entities;
using Registeration2.Common.DTOs.UsersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using static Register.Common.Enums;

namespace CyberResilience.DAL.CustomRepositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(UnitOfWork uow) : base(uow) { }

        // Hamzeh : create a Common project 

        //public bool IsUserActive(string AspNetUserId)
        //{
        //    var user = GetQuerable(x => x.AspNetUserId == AspNetUserId).FirstOrDefault();
        //    if (user.StatusId == (int)UserStatus.ActiveUser)//this is enums 
        //                                                    // whta is enums : it is a fixed value which used to mapping between two properties 
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //now you should add creat user function to the DAl 
        public bool CreateStudent(UsersDTO userDto)
        {
            try
            {
                var record = new User()
                {
                    Email = userDto.Email,
                    FirstNameAr = userDto.FirstNameAr,
                    FirstNameEn = userDto.FirstNameEn,
                    LastNameAr = userDto.LastNameAr,
                    LastNameEn = userDto.LastNameEn,
                    //complete another fields 

                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("CrateUser", "An error occurred while trying to  CrateUser Record - DAL");
                Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return false;
            }

        }
        public bool RegisterStudent(UsersDTO userDTO)
        {
            try
            {

                var record = new User()
                {
                    Email = userDTO.Email,
                    FirstNameAr = userDTO.FirstNameAr,
                    FirstNameEn = userDTO.FirstNameEn,
                    LastNameAr = userDTO.LastNameAr,
                    LastNameEn = userDTO.LastNameEn,
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("RegisterUser", "An error occurred while trying to  CrateUser Record - DAL");
                Tracer.Error(ex);
                return false;
            }
        }
        public UsersDTO GetUserById(int id)
        {

            var user = GetQuerable(x => x.Id == id).FirstOrDefault();

            UsersDTO dto = new UsersDTO();

            dto.Id = user.Id;
            dto.GenderId = user.GenderId;
            dto.FirstNameAr = user.FirstNameAr;
            dto.FirstNameEn = user.FirstNameEn;
            dto.LastNameAr = user.LastNameAr;
            dto.LastNameEn = user.LastNameEn;
            return dto;
        }

        public bool UpdateStudent(UsersDTO userDTO)
        {
            try
            {
                var record = new User()
                {
                    Email = userDTO.Email,
                    FirstNameAr = userDTO.FirstNameAr,
                    FirstNameEn = userDTO.FirstNameEn,
                    LastNameAr = userDTO.LastNameAr,
                    LastNameEn = userDTO.LastNameEn,
                    Id = userDTO.Id
                };

                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("UpdateUser", "An error occurred while trying to  CrateUser Record - DAL");
                Tracer.Error(ex);
                return false;
            }
        }


        public bool DeleteStudent(int id)
        {
            try
            {
                User user = GetQuerable(x => x.Id == id).FirstOrDefault();



                Delete(user);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteUser", "An error occurred while trying to  CrateUser Record - DAL");
                Tracer.Error(ex);
                return false;
            }
        }

        public List<UsersDTO> GetStudentsList()
        {
            //void
            var users = GetQuerable(x => x.Id > 0).Select(u => new UsersDTO()
            {
                Id = u.Id,
                Email = u.Email,
                FirstNameAr = u.FirstNameAr,
                LastNameAr=u.LastNameAr,
                FirstNameEn = u.FirstNameEn,
                LastNameEn = u.LastNameEn
            }).ToList();


            return users;

            //List<AspNetUser> entities = new List<AspNetUser>();
            //List<AspNetUserDTO> dtos = new List<AspNetUserDTO>();
            //AspNetUserDTO obj = new AspNetUserDTO();
            //entities = GetQuerable(x => x.Id != string.Empty).ToList();
            //foreach(var item in entities)
            //{
            //    obj.Email = item.Email;
            //    obj.Id = item.Email;
            //    obj.UserName = item.UserName;
            //}
            //dtos.Add(obj);
            //return dtos;





        }






    }
}