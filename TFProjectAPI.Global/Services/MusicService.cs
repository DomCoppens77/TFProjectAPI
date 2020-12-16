using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class MusicService : IMusicService<Music>
    {
        private string where = "GMUSIC";
        private string Str_Get = "Select * From [AppUser].[V_Music_Full]";

        public IEnumerable<Music> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic());
            }
            catch (Exception e) { throw e; }
        }

        public Music Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Music> GetPage(int page, int jump)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[PaginateMusic]", true);
                command.AddParameter("page", page);
                command.AddParameter("jump", jump);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic());
            }
            catch (Exception e) { throw e; }
        }

        public int GetPageCount(int jump)
        {
            try
            {
                DBCommand commandP = new DBCommand("[AppUser].[CountPage]", true);
                commandP.AddParameter("Jump", jump);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(commandP);
            }
            catch (Exception e) { throw e; }
        }

        public Music Add(Music mu)
        {
            string meth = "(" + where + ")(" + "ADD" + ")";
            try
            {
                if (mu is null) throw new DataException("Music Data empty " + meth);

                DBCommand command = new DBCommand("[AppUser].[AddMusic]", true);
                /* OBJECT TABLE*/
                command.AddParameter("Price", mu.Price);
                command.AddParameter("Curr", mu.Curr);
                command.AddParameter("ShopId", mu.ShopId);
                command.AddParameter("Date", mu.Date);
                command.AddParameter("OTypeId", mu.TypeId);
                command.AddParameter("Signed", mu.Signed);
                command.AddParameter("SignedBy", mu.SignedBy);
                command.AddParameter("EAN", mu.EAN);
                command.AddParameter("EAN_EXT", mu.EAN_EXT);
                command.AddParameter("Comment1", mu.Comment1);
                command.AddParameter("Comment2", mu.Comment2);
                /* OBJECT MUSIC*/
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
                command.AddParameter("Ctry", mu.Ctry);
                mu.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
                return mu;
            }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Music mu)
        {
            string meth = "(" + where + ")(" + "UPD" + ")";
            try
            {
                if (mu is null) throw new DataException("Music Data empty " + meth);
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
                command.AddParameter("Ctry", mu.Ctry);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelMusic]", true);
                command.AddParameter("Id", id);
                return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<string> ListBand()
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[ListBand]", true);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => { return dr["Band"].ToString(); });
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Music> FindBand(string band)
        {
            try
            {
                if (band.Length == 0) throw new ArgumentOutOfRangeException("Band to search different than BLANK (" + where + ")");
                DBCommand command = new DBCommand("[AppUser].[FindBand]", true);
                command.AddParameter("Band", band);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic());
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Music> FindEan(string ean)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[FindEAN]", true);
                command.AddParameter("EAN", ean);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToMusic());
            }
            catch (Exception e) { throw e; }
        }
    }
}
