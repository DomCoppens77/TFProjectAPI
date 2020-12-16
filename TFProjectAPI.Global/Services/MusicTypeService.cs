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
    public class MusicTypeService : IMusicTypeService<MusicType>
    {
        private string where = "GMT";
        private string Str_Get = "Select * From [AppUser].[V_MusicType]";

        public IEnumerable<MusicType> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicType());
            }
            catch (Exception e) { throw e; }
        }

        public MusicType Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicType()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public MusicType Add(MusicType mt)
        {
            try
            {
                if (mt is null) throw new DataException("Music Type Data empty (" + where + ") (ADD)");

                DBCommand command = new DBCommand("[AppUser].[AddMusicType]", true);
                command.AddParameter("Name", mt.Name);
                mt.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
                return mt;
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(MusicType mt)
        {
            try
            {
                if (mt is null) throw new DataException("Music Type Data empty (" + where + ") (UPD)");
                DBCommand command = new DBCommand("[AppUser].[UpdMusicType]", true);
                command.AddParameter("Id", mt.Id);
                command.AddParameter("Name", mt.Name);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelMusicType]", true);
                command.AddParameter("Id", id);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public int MusicTypeIsUsed(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckMusicType]", true);
                command.AddParameter("Id", id);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
