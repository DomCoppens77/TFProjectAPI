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
    public class MusicTypeService : IMusicTypeService<MusicType>
    {
        private string where = "CMT";
        public IEnumerable<MusicType> Get()
        {
            try { return GS.Instance.MusicTypeService.Get().Select(mt => mt.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public MusicType Get(int id)
        {
            try { return GS.Instance.MusicTypeService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }

        public MusicType Add(MusicType mt)
        {
            try
            {
                if (mt is null) throw new DataException("Music Type Data empty (" + where + ") (ADD)");
                if (mt.Name.Length < 1) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD)");
                return GS.Instance.MusicTypeService.Add(mt.ToGlobal()).ToClient();
            }
            catch (Exception e) { throw e; }
        }
        public bool Upd(MusicType mt)
        {
            try
            {
                if (mt is null) throw new DataException("Music Type Data empty (" + where + ") (UPD)");
                if (mt.Name.Length < 1) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD)");
                return GS.Instance.MusicTypeService.Upd(mt.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }
        public bool Del(int id)
        {
            try { return GS.Instance.MusicTypeService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public int MusicTypeIsUsed(int id)
        {
            try { return GS.Instance.MusicTypeService.MusicTypeIsUsed(id); }
            catch (Exception e) { throw e; }
        }
    }
}
