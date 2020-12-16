using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SM = TFProjectAPI.Client.Models;

namespace TFProjectAPI.Models.API.Music
{
    public class MusicDTO
    {

        private int _totalRecords;
        private int _currentPage;
        private int _maxPages;
        private int _jump;
        private IEnumerable<SM.Music> _musics;

        public MusicDTO(int totalrecods, int maxpages,  int currentpage, int jump, IEnumerable<SM.Music> musics = null)
        {
            TotalRecords = totalrecods;
            MaxPages = maxpages;
            CurrentPage = currentpage;
            Jump =  jump;
            Musics = musics;
        }

        public int TotalRecords
        {
            get
            {
                return _totalRecords;
            }

            set
            {
                _totalRecords = value;
            }
        }

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }

            set
            {
                _currentPage = value;
            }
        }

        public int Jump
        {
            get
            {
                return _jump;
            }

            set
            {
                _jump = value;
            }
        }

        public IEnumerable<SM.Music> Musics
        {
            get
            {
                return _musics;
            }

            set
            {
                _musics = value;
            }
        }

        public int MaxPages
        {
            get
            {
                return _maxPages;
            }

            set
            {
                _maxPages = value;
            }
        }
    }
}
