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
    public class MusicFormatService : IMusicFormatService<MusicFormat>
    {
        private string where = "CMF";
        public IEnumerable<MusicFormat> Get()
        {
            try { return GS.Instance.MusicFormatService.Get().Select(mf => mf.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public MusicFormat Get(int id)
        {
            try { return GS.Instance.MusicFormatService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }
        public MusicFormat Add(MusicFormat mf)
        {
            try
            {
                if (mf is null) throw new DataException("Music Format Data empty (" + where + ") (ADD)");
                if (mf.Name.Length < 1) throw new DataException("Issue with Data entered for Add (" + where + ") (ADD)");
                return GS.Instance.MusicFormatService.Add(mf.ToGlobal()).ToClient();
            }
            catch (Exception e) { throw e; }
        }
        public bool Upd(MusicFormat mf)
        {
            try
            {
                if (mf is null) throw new DataException("Music Type Data empty (" + where + ") (UPD)");
                if (mf.Name.Length < 1) throw new DataException("Issue with Data entered for Add (" + where + ") (UPD)");
                return GS.Instance.MusicFormatService.Upd(mf.ToGlobal());
            }
            catch (Exception e) { throw e; }
        }
        public bool Del(int id)
        {
            try { return GS.Instance.MusicFormatService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public int MusicFormatIsUsed(int id)
        {
            try { return GS.Instance.MusicFormatService.MusicFormatIsUsed(id); }
            catch (Exception e) { throw e; }
        }
    }
}
