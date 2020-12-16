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
    public class GeneralTypesService : IGeneralTypeService<GeneralType, GenYearPurch, GenObjectSearch>
    {
        private string where = "GGT";
        private string Str_Get = "Select * From [AppUser].[V_GeneralType]";
        public IEnumerable<GeneralType> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToGenType());
            }
            catch (Exception e) { throw e; }
        }

        public GeneralType Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToGenType()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public int IsUsed(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckGenType]", true);
                command.AddParameter("Id", id);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenYearPurch> GetYP()
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[AppYearPurchases]", true);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToGenYP());
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenObjectSearch> SearchText(int page, int jump, string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (ST)");
                DBCommand command = new DBCommand("[AppUser].[SearchODesc]", true);
                command.AddParameter("page", page);
                command.AddParameter("jump", jump);
                command.AddParameter("search", search);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToObjSearch());
            }
            catch (Exception e) { throw e; }
        }

        public int SearchTextCnt(string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (STC)");
                DBCommand command = new DBCommand("[AppUser].[SearchODescCnt]", true);
                command.AddParameter("search", search);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenObjectSearch> SearchEAN(int page, int jump, string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (SE)");
                DBCommand command = new DBCommand("[AppUser].[SearchOEAN]", true);
                command.AddParameter("page", page);
                command.AddParameter("jump", jump);
                command.AddParameter("EAN", search);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToObjSearch());
            }
            catch (Exception e) { throw e; }
        }

        public int SearchEANcnt(string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (SEC)");
                DBCommand command = new DBCommand("[AppUser].[SearchOEANCnt]", true);
                command.AddParameter("EAN", search);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
