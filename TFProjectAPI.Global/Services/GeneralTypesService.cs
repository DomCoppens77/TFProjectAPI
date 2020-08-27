using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class GeneralTypesService : IGeneralTypeService<GeneralType>
    {
        public IEnumerable<GeneralType> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_GeneralType];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToGenType());
        }

        public GeneralType Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_GeneralType] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToGenType()).SingleOrDefault();
        }

        public int IsUsed(int id)
        {
            //DBCommand command = new DBCommand("[AppUser].[CheckGenType]", true);
            //command.AddParameter("Id", id);

            DBCommand command = new DBCommand("SELECT COUNT(*) FROM [AppUser].[V_Object] where [TypeID] = @Id; ");
            command.AddParameter("Id", id);
            int i = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return i;

        }
    }
}
