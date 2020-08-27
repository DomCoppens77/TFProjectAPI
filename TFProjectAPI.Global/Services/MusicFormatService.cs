using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class MusicFormatService : IMusicFormatService<MusicFormat>
    {
        public MusicFormat Add(MusicFormat mf)
        {
            DBCommand command = new DBCommand("[AppUser].[AddMusicFormat]", true);
            command.AddParameter("Name", mf.Name);

            mf.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return mf;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelMusicFormat]", true);
            command.AddParameter("Id", id);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }

        public IEnumerable<MusicFormat> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_MusicFormat];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicFrmt());
        }

        public MusicFormat Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_MusicFormat] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusicFrmt()).SingleOrDefault();
        }

        public int MusicFormatIsUsed(int id)
        {
            //DBCommand command = new DBCommand("[AppUser].[CheckMusicFormat]", true);
            //command.AddParameter("Id", id);

            DBCommand command = new DBCommand("SELECT COUNT(*) FROM [AppUser].[V_Music] where [FormatId] = @Id; ");
            command.AddParameter("Id", id);
            int i = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return i;
        }

        public bool Upd(MusicFormat mf)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdMusicFormat]", true);
            command.AddParameter("Id", mf.Id);
            command.AddParameter("Name", mf.Name);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);

        }
    }
}
