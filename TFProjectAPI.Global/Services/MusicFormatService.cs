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
    public class MusicFormatService : IMusicFormatService<MusicFormat>
    {
        private string where = "GMF";
        private string Str_Get = "Select * From [AppUser].[V_MusicFormat]";

        public IEnumerable<MusicFormat> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicFrmt());
            }
            catch (Exception e) { throw e; }
        }

        public MusicFormat Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicFrmt()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public MusicFormat Add(MusicFormat mf)
        {
            try
            {
                if (mf is null) throw new DataException("Music Format Data empty (" + where + ")  (ADD)");
                DBCommand command = new DBCommand("[AppUser].[AddMusicFormat]", true);
                command.AddParameter("Name", mf.Name);
                mf.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
                return mf;
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(MusicFormat mf)
        {
            try
            {
                if (mf is null) throw new DataException("Music Format Data empty (" + where + ")  (UPD)");
                DBCommand command = new DBCommand("[AppUser].[UpdMusicFormat]", true);
                command.AddParameter("Id", mf.Id);
                command.AddParameter("Name", mf.Name);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelMusicFormat]", true);
                command.AddParameter("Id", id);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public int MusicFormatIsUsed(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckMusicFormat]", true);
                command.AddParameter("Id", id);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
