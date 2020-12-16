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

        bool ChangePasswd(string email, string oldPasswd, string passwd);

        bool ResetPasswd(string email, string secretAnswer, string passwd);

        TUser Login(string email, string passwd);

        bool EmailIsUsed(string email);

        bool ReactivateUser(int id);
    }
}
