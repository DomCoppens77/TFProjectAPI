using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class MusicService : IMusicService<Music>
    {
        public Music Add(Music mu)
        {
            DBCommand command = new DBCommand("[AppUser].[AddMusic]", true);
            /* OBJECT TABLE*/
            command.AddParameter("Price", mu.Price );
            command.AddParameter("Curr", mu.Curr );
            command.AddParameter("ShopId", mu.ShopId );
            command.AddParameter("Date", mu.Date );
            command.AddParameter("OTypeId", mu.TypeId );
            command.AddParameter("Signed", mu.Signed );
            command.AddParameter("SignedBy", mu.SignedBy );
            command.AddParameter("EAN", mu.EAN );
            command.AddParameter("EAN_EXT", mu.EAN_EXT );
            command.AddParameter("Comment1", mu.Comment1 );
            command.AddParameter("Comment2", mu.Comment2 );
            /* OBJECT MUSIC*/
            command.AddParameter("Band", mu.Band );
            command.AddParameter("Title", mu.Title );
            command.AddParameter("YEAR", mu.YEAR );
            command.AddParameter("TRACKS", mu.TRACKS );
            command.AddParameter("NbCDs", mu.NbCDs );
            command.AddParameter("NbDvds", mu.NbDvds );
            command.AddParameter("NbLps", mu.NbLps );
            command.AddParameter("MTypeId", mu.MTypeId );
            command.AddParameter("FormatId", mu.FormatId );
            command.AddParameter("SerialNbr", mu.SerialNbr );
            command.AddParameter("Ctry", mu.Ctry);

            mu.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return mu;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelMusic]", true);
            command.AddParameter("Id", id);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }

        public IEnumerable<Music> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Music_Full];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic());
        }

        public Music Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Music_Full] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic()).SingleOrDefault();
        }

        public bool Upd(Music mu)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdMusic]", true);
            command.AddParameter("Id", mu.Id);
            /* OBJECT TABLE*/
            command.AddParameter("Price", mu.Price);
            command.AddParameter("Curr", mu.Curr);
            command.AddParameter("ShopId", mu.ShopId);
            command.AddParameter("Date", mu.Date);
            command.AddParameter("OTypeId", mu.TypeId); /* Need to be updated ?? dont think so */
            command.AddParameter("Signed", mu.Signed);
            command.AddParameter("SignedBy", mu.SignedBy);
            command.AddParameter("EAN", mu.EAN);
            command.AddParameter("EAN_EXT", mu.EAN_EXT);
            command.AddParameter("Comment1", mu.Comment1);
            command.AddParameter("Comment2", mu.Comment2);
            /*MUSIC TABLE*/
            command.AddParameter("Band", mu.Band);
            command.AddParameter("Title", mu.Title);
            command.AddParameter("YEAR", mu.YEAR);
            command.AddParameter("TRACKS", mu.TRACKS);
            command.AddParameter("NbCDs", mu.NbCDs);
            command.AddParameter("NbDvds", mu.NbDvds);
            command.AddParameter("NbLps", mu.NbLps);
            command.AddParameter("MTypeId", mu.MTypeId);
            command.AddParameter("FormatId", mu.FormatId);
            command.AddParameter("SerialNbr", mu.SerialNbr);

            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }
    }
}
