using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class CountryService : ICountryService<Country>
    {
        public void Add(Country ctry)
        {
            GS.Instance.CountryService.Add(ctry.ToGlobal());
        }

        public bool Del(string ISO)
        {
            return GS.Instance.CountryService.Del(ISO);
        }

        public IEnumerable<Country> Get()
        {
            return GS.Instance.CountryService.Get().Select(c => c.ToClient());
        }

        public Country Get(string ISO)
        {
            return GS.Instance.CountryService.Get(ISO)?.ToClient();
        }

        public bool Upd(Country ctry)
        {
            return GS.Instance.CountryService.Upd(ctry.ToGlobal());
        }
    }
}
