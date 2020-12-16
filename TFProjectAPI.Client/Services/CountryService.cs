using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class CountryService : ICountryService<Country>
    {
        private string where = "CCTRY";
        public IEnumerable<Country> Get()
        {
            try { return GS.Instance.CountryService.Get().Select(c => c.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Country Get(string ISO)
        {
            try
            {
                if (ISO.Length != 2) throw new DataException("ISO code must be filled (" + where + ") (USED)");
                return GS.Instance.CountryService.Get(ISO)?.ToClient();
            }
            catch (Exception e) { throw e; }
        }
        public void Add(Country ctry)
        {
            try
            {
                if (ctry is null) throw new DataException("Country Data empty (" + where + ") (ADD)");
                if (ctry.ISO.Length != 2) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD)");
                GS.Instance.CountryService.Add(ctry.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }
        public bool Upd(Country ctry)
        {
            try
            {
                if (ctry is null) throw new DataException("Country Data empty (" + where + ") (UPD)");
                if (ctry.ISO.Length != 2) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD)");
                return GS.Instance.CountryService.Upd(ctry.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }
        public bool Del(string ISO)
        {
            try
            {
                return GS.Instance.CountryService.Del(ISO);
            }
            catch (Exception e) { throw e; }
        }

        public int IsUsed(string ISO)
        {
            try
            {
                if (ISO.Length != 2) throw new DataException("ISO code must be filled (" + where + ") (USED)");
                return GS.Instance.CountryService.IsUsed(ISO);
            }
            catch (Exception e) { throw e; }
        }
    }
}
