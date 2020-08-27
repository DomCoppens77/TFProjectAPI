using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class GeneralTypesService : IGeneralTypeService<GeneralType>
    {
        public IEnumerable<GeneralType> Get()
        {
            return GS.Instance.GeneralTypeService.Get().Select(gt => gt.ToClient());
        }

        public GeneralType Get(int id)
        {
            return GS.Instance.GeneralTypeService.Get(id)?.ToClient();
        }

        public int IsUsed(int id)
        {
            return GS.Instance.GeneralTypeService.IsUsed(id);
        }
    }
}
