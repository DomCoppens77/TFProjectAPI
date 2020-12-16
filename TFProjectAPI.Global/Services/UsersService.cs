using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class UsersService : IUsersService<User>
    {
        private string where = "GU";
        private string Str_CheckEmail = "Select count(*) from [AppUser].[V_Users] where Email = @Email";
        private string Str_Get = "Select Id, FirstName,LastName, Email, Active , Status, ConnectionCount, ConnectionLast, Avatar From [AppUser].[V_Users]";
        public IEnumerable<User> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToUser());
            }
            catch (Exception e) { throw e; }
        }

        public User Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public User Add(User user)
        {
            try
            {
                if (user is null) throw new DataException("User Data empty (" + where + ") (ADD)");
                if (user.Email.Length == 0 || user.Passwd.Length == 0) throw new DataException("Email &/or Password Data empty (" + where + ") ADD)");

                DBCommand command1 = new DBCommand(Str_CheckEmail);
                command1.AddParameter("Email", user.Email ?? (object)DBNull.Value);

                if (1 == (int)ServiceLocator.Instance.Connection.ExecuteScalar(command1)) throw new DataException("Email Is already Used (" + where + ") ADD)");

                DBCommand command = new DBCommand("[AppUser].[AddUser]", true);
                command.AddParameter("FirstName", user.FirstName);
                command.AddParameter("LastName", user.LastName);
                command.AddParameter("Email", user.Email);
                command.AddParameter("Passwd", user.Passwd);
                command.AddParameter("SecretAnswer", user.SecretAnswer);
                command.AddParameter("Avatar", user.Avatar);
                user.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
                user.Passwd = "";
                user.SecretAnswer = "";

                return user;
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(int id, User user)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException(" ID must be greater than 0 (" + where + ") (UPD)");
                if (user is null) throw new DataException("Upd User Data empty (" + where + ") (UPD)");

                DBCommand command = new DBCommand("[AppUser].[UpdUser]", true);
                command.AddParameter("Id", id);
                command.AddParameter("LastName", user.LastName);
                command.AddParameter("FirstName", user.FirstName);
                //command.AddParameter("Email", user.Email);
                command.AddParameter("Status", user.Status);
                command.AddParameter("Avatar", user.Avatar);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelUser]", true);
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public User Login(string email, string passwd)
        {
            try
            {
                if (email.Length == 0 || passwd.Length == 0) throw new DataException("Email &/or Password Data empty (" + where + ") (LOGIN))");

                DBCommand command = new DBCommand("[AppUser].[CheckUser]", true);
                command.AddParameter("Email", email);
                command.AddParameter("Passwd", passwd);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, r => r.ToUser()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public bool EmailIsUsed(string email)
        {
            try
            {
                if (email.Length == 0) throw new DataException("EMAIL Data empty (" + where + ") (USED)");

                DBCommand command = new DBCommand(Str_CheckEmail);
                command.AddParameter("Email", email ?? (object)DBNull.Value);
                return 1 == (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool ChangePasswd(string email, string oldPasswd, string passwd)
        {
            try
            {
                if (email.Length != 0 && passwd.Length != 0 && oldPasswd.Length != 0)
                {
                    DBCommand command = new DBCommand("[AppUser].[UserChgPasswd]", true);
                    command.AddParameter("Email", email);
                    command.AddParameter("OldPasswd", oldPasswd);
                    command.AddParameter("Passwd", passwd);

                    return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
                }
                else throw new DataException("ChangePasswd Data empty (" + where + ") (CHG)");
            }
            catch (Exception e) { throw e; }
        }

        public bool ResetPasswd(string email, string secretAnswer, string passwd)
        {
            try
            {
                if (email.Length != 0 && passwd.Length != 0 && secretAnswer.Length != 0)
                {
                    DBCommand command = new DBCommand("[AppUser].[UserResetPasswd]", true);
                    command.AddParameter("Email", email);
                    command.AddParameter("SecretAnswer", secretAnswer);
                    command.AddParameter("Passwd", passwd);

                    return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
                }
                else throw new DataException("ResetPasswd Data empty (" + where + ") (RESET)");
            }
            catch (Exception e) { throw e; }
        }

        public bool ReactivateUser(int id)
        {
            try
            {
                if (id < 1) throw new IndexOutOfRangeException(" ID must be greater than 0 (" + where + ") (REACT)");
                DBCommand command = new DBCommand("[AppUser].[ReactiveUser]", true);
                command.AddParameter("Id", id);

                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }
    }
}
