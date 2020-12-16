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
    public class GeneralTypesService : IGeneralTypeService<GeneralType,GenYearPurch, GenObjectSearch>
    {
        private string where = "CGT";
        public IEnumerable<GeneralType> Get()
        {
            try { return GS.Instance.GeneralTypeService.Get().Select(gt => gt.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public GeneralType Get(int id)
        {
            try { return GS.Instance.GeneralTypeService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }
        public int IsUsed(int id)
        {
            try { return GS.Instance.GeneralTypeService.IsUsed(id); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenYearPurch> GetYP()
        {
            try { return GS.Instance.GeneralTypeService.GetYP()?.Select(yp => yp.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenObjectSearch> SearchText(int page, int jump, string search)
        {
            try {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (ST)");
                return GS.Instance.GeneralTypeService.SearchText(page, jump, search)?.Select(st => st.ToClient());
            }
            catch (Exception e) { throw e; }
        }

        public int SearchTextCnt(string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (STC)");
                return GS.Instance.GeneralTypeService.SearchTextCnt(search); 
            }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<GenObjectSearch> SearchEAN(int page, int jump, string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (SE)");
                return GS.Instance.GeneralTypeService.SearchEAN(page, jump, search)?.Select(st => st.ToClient());
            }
            catch (Exception e) { throw e; }
        }

        public int SearchEANcnt(string search)
        {
            try
            {
                if (search.Length == 0) throw new DataException("Search can't be BLANK (" + where + ") (SEC)");
                return GS.Instance.GeneralTypeService.SearchEANcnt(search);
            }
            catch (Exception e) { throw e; }
        }
    }
}
