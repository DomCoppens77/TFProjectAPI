using System;
using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class UsersService : IUsersService<User>
    {
        public User Add(User user)
        {
            DBCommand command = new DBCommand("[AppUser].[AddUser]", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            user.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return user;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelUser]", true);
            command.AddParameter("Id", id);

            /* is delete return 1 ou à et donc pourrais teset au lieu de renvoyer simplue true */
            /* return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1 ; */

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<User> Get()
        {
            DBCommand command = new DBCommand("Select Id, FirstName,LastName, Email, Active , Status, ConnectionCount, ConnectionLast From [AppUser].[V_Users];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public User Get(int id)
        {
            DBCommand command = new DBCommand("select Id, FirstName,LastName, Email, Active , Status, ConnectionCount, ConnectionLast From [AppUser].[V_Users] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public bool Upd(int id, User user)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdUser]", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Status", user.Status);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public User Login(string email, string passwd)
        {
                DBCommand command = new DBCommand("[AppUser].[CheckUser]", true);
                command.AddParameter("Email", email);
                command.AddParameter("Passwd", passwd);

                return ServiceLocator.Instance.Connection.ExecuteReader(command, r => r.ToUser()).SingleOrDefault();
        }

        public bool EmailIsUsed(string email)
        {
            DBCommand command = new DBCommand("Select count(*) from [AppUser].[V_Users] where Email = @Email");
            command.AddParameter("Email", email ?? (object)DBNull.Value);

            return 1 == (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
        }

        public void ChangePasswd(string email, string oldPasswd, string passwd)
        {
            DBCommand command = new DBCommand("[AppUser].[UserChgPasswd]", true);
            command.AddParameter("Email", email);
            command.AddParameter("OldPasswd", oldPasswd);
            command.AddParameter("Passwd", passwd);

            ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }
    }
}
