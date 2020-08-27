using System.Collections.Generic;

namespace TFProjectAPI.Repo
{
    public interface IUsersService<TUser>
    {
        IEnumerable<TUser> Get();

        TUser Get(int id);

        TUser Add(TUser user);

        bool Upd(int id, TUser user);

        bool Del(int id);

        void ChangePasswd(string email, string oldPasswd, string passwd);

        TUser Login(string email, string passwd);

        bool EmailIsUsed(string email);
    }
}
