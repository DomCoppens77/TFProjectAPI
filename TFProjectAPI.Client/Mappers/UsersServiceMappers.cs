using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class Mappers
    {
        internal static GM.User ToGlobal(this User entity)
        {
            return new GM.User() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Passwd = entity.Passwd, Active = entity.Active, Status = entity.Status, ConnectionCount = entity.ConnectionCount, ConnectionLast = entity.ConnectionLast };
        }

        internal static User ToClient(this GM.User entity)
        {
            if (entity is null) // Test Null if User dont succeed to be found (Login with wrong credential or user not existing at all
                return null;
            else
                return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.Passwd, entity.Active, entity.Status, entity.ConnectionCount, entity.ConnectionLast);

        }
    }
}
