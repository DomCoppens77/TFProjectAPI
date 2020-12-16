using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TFProjectAPI.Client.Mappers;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using GS = TFProjectAPI.Global.Services.ServiceLocator;

namespace TFProjectAPI.Client.Services
{
    public class MusicService : IMusicService<Music>
    {
        private string where = "CMUSIC";
        public IEnumerable<Music> Get()
        {
            try { return GS.Instance.MusicService.Get().Select(m => m.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Music Get(int id)
        {
            try { return GS.Instance.MusicService.Get(id)?.ToClient(); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Music> GetPage(int page, int jump)
        {
            try { return GS.Instance.MusicService.GetPage(page, jump).Select(m => m.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public Music Add(Music mu)
        {
            try {
                if (mu is null) throw new DataException("Music Data empty (" + where + ")(" + "ADD" + ")");
                return GS.Instance.MusicService.Add(mu.ToGlobal()).ToClient(); }
            catch (Exception e) { throw e; }
        }

        public bool Upd(Music mu)
        {
            try {
                if (mu is null) throw new DataException("Music Data empty (" + where + ")(" + "UPD" + ")");
                return GS.Instance.MusicService.Upd(mu.ToGlobal()); }
            catch (Exception e) { throw e; }
        }
        public bool Del(int id)
        {
            try { return GS.Instance.MusicService.Del(id); }
            catch (Exception e) { throw e; }
        }

        public int GetPageCount(int jump)
        {
            if (jump <= 0) jump = 50;
            try   { return GS.Instance.MusicService.GetPageCount(jump); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<string> ListBand()
        {
            try { return GS.Instance.MusicService.ListBand(); }
            catch (SqlException e) { throw e; }
        }

        public IEnumerable<Music> FindBand(string band)
        {
            try { return GS.Instance.MusicService.FindBand(band).Select(m => m.ToClient()); }
            catch (Exception e) { throw e; }
        }

        public IEnumerable<Music> FindEan(string ean)
        {
            try { return GS.Instance.MusicService.FindEan(ean).Select(m => m.ToClient()); }
            catch (Exception e) { throw e; }
        }
    }
}
