using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Register2.dal.Entities;
using Registeration2.Common.DTO_s.UsersDTO;

namespace CyberResilience.DAL.CustomRepositories
{

    //calss structure : 1) class name - access modifier
    public class AspNetUserRepository : Repository<AspNetUser>
    {
        //calss structure : constructor()
        public AspNetUserRepository(UnitOfWork uow) : base(uow) { }
        //calss structure :functions : access modifier - return data type - functionName(params1,params2....)
        public AspNetUser GetUserByName(string userName)
        {
            var user = GetQuerable(x => x.UserName.Trim().ToLower() == userName.Trim().ToLower()).FirstOrDefault();
            return user;
        }
        public bool IsAlreadyRegistered(string SerialNumber)
        {
            var user = GetQuerable(x => x.Id.Trim() == SerialNumber.Trim()).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string RegisterUser(AspNetUserDTO user)
        {
            try
            {
                var record = new AspNetUser()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                };
                Create(record);
                _uow.Save();
                //record.AspNetRoles.Add(new AspNetRole() { Id=(int)UserRole.Admin});
                if (!string.IsNullOrEmpty(record.Id))
                {
                    return record.Id;
                }
                return null;
            }
            catch (Exception ex)
            {
                //Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return "";
            }

        }


        public string GetUserIdByUserName(string UserName)
        {

            var userId = GetQuerable(x => x.UserName == UserName).FirstOrDefault().Id;

            if (!String.IsNullOrEmpty(userId))
            {
                return userId;
            }
            {
                return "";
            }
        }

        public List<AspNetUserDTO> GetStudents()
        {
            //void
            var users = GetQuerable(x => x.Id != string.Empty).Select(u => new AspNetUserDTO()
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName
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
