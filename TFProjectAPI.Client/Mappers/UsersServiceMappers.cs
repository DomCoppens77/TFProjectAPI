using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class Mappers
    {
        internal static GM.User ToGlobal(this User e)
        {
            return new GM.User() { Id = e.Id, LastName = e.LastName, FirstName = e.FirstName, Email = e.Email, Passwd = e.Passwd, Active = e.Active, Status = e.Status, ConnectionCount = e.ConnectionCount, ConnectionLast = e.ConnectionLast, SecretAnswer = e.SecretAnswer, Avatar = e.Avatar };
        }

        internal static User ToClient(this GM.User e)
        {
            if (e is null) // Test Null if User dont succeed to be found (Login with wrong credential or user not existing at all
                return null;
            else
                return new User(e.Id, e.LastName, e.FirstName, e.Email, e.Passwd, e.Active, e.Status, e.ConnectionCount, e.ConnectionLast, e.SecretAnswer, e.Avatar);

        }
    }
}
