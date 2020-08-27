using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class UsersService : IUsersService<User>
    {
        public User Add(User user)
        {
            return GS.Instance.UsersService.Add(user.ToGlobal()).ToClient();
        }

        public void ChangePasswd(string email, string oldPasswd, string passwd)
        {
            GS.Instance.UsersService.ChangePasswd(email, oldPasswd, passwd);
        }

        public bool Del(int id)
        {
            return GS.Instance.UsersService.Del(id);
        }

        public bool EmailIsUsed(string email)
        {
            return GS.Instance.UsersService.EmailIsUsed(email);
        }

        public IEnumerable<User> Get()
        {
            return GS.Instance.UsersService.Get().Select(U => U.ToClient());
        }

        public User Get(int id)
        {
            return GS.Instance.UsersService.Get(id)?.ToClient();
        }

        public User Login(string email, string passwd)
        {
            return GS.Instance.UsersService.Login(email, passwd).ToClient();
        }

        public bool Upd(int id, User user)
        {
            return GS.Instance.UsersService.Upd(id, user.ToGlobal());
        }
    }
}
