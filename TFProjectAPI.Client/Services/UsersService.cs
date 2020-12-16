using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class UsersService : IUsersService<User>
    {
        private string where = "CU";
        public IEnumerable<User> Get()
        {
            try { return GS.Instance.UsersService.Get().Select(U => U.ToClient());}
            catch (Exception e) { throw e; }
        }

        public User Get(int id)
        {
            try { return GS.Instance.UsersService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }

        public User Add(User user)
        {
            try { if (user is null) throw new DataException("User Data empty (" + where + ") (ADD)");
                return GS.Instance.UsersService.Add(user.ToGlobal()).ToClient(); }
            catch (Exception e) { throw e; }
        }

        public bool Upd(int id, User user)
        {
            try { if (user is null) throw new DataException("Upd User Data empty (" + where + ") (UPD)");
                  return GS.Instance.UsersService.Upd(id, user.ToGlobal()); }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try { return GS.Instance.UsersService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public User Login(string email, string passwd)
        {
            try { return GS.Instance.UsersService.Login(email, passwd).ToClient(); }
            catch (Exception e) { throw e; }
        }

        public bool EmailIsUsed(string email)
        {
            try { return GS.Instance.UsersService.EmailIsUsed(email); }
            catch (Exception e) { throw e; }
        }

        public bool ChangePasswd(string email, string oldPasswd, string passwd)
        {
            try { return GS.Instance.UsersService.ChangePasswd(email, oldPasswd, passwd); }
            catch (Exception e) { throw e; }
        }

        public bool ResetPasswd(string email, string secretAnswer, string passwd)
        {
            try { return GS.Instance.UsersService.ResetPasswd(email, secretAnswer, passwd); }
            catch (Exception e) { throw e; }
        }

        public bool ReactivateUser(int id)
        {
            try { return GS.Instance.UsersService.ReactivateUser(id); }
            catch (Exception e) { throw e; }
        }
    }
}
