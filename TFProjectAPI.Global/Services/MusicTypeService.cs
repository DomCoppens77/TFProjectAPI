using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class MusicTypeService : IMusicTypeService<MusicType>
    {
        public MusicType Add(MusicType mt)
        {
            DBCommand command = new DBCommand("[AppUser].[AddMusicType]", true);
            command.AddParameter("Name", mt.Name);

            mt.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return mt;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelMusicType]", true);
            command.AddParameter("Id", id);

            return 1  == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }

        public IEnumerable<MusicType> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_MusicType];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicType());
        }

        public MusicType Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_MusicType] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicType()).SingleOrDefault();
        }

        public int MusicTypeIsUsed(int id)
        {
            //DBCommand command = new DBCommand("[AppUser].[CheckMusicType]", true);
            //command.AddParameter("Id", id);

            DBCommand command = new DBCommand("SELECT COUNT(*) FROM [AppUser].[V_Music] where [MTypeId] = @Id; ");
            command.AddParameter("Id", id);
            int i = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return i;

        }

        public bool Upd(MusicType mt)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdMusicType]", true);
            command.AddParameter("Id", mt.Id);
            command.AddParameter("Name", mt.Name);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);

        }
    }
}
