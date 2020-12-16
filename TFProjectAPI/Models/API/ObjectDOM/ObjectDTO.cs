using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFProjectAPI.Client.Models;

namespace TFProjectAPI.Models.API.ObjectDOM
{
    public class ObjectDTO
    {
        private int _totalRecords;
        private int _currentPage;
        private int _maxPages;
        private int _jump;
        private IEnumerable<GenObjectSearch> _objs;

        public ObjectDTO(int totalrecods, int maxpages, int currentpage, int jump, IEnumerable<GenObjectSearch> objs = null)
        {
            TotalRecords = totalrecods;
            MaxPages = maxpages;
            CurrentPage = currentpage;
            Jump = jump;
            Objs = objs;
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

        public IEnumerable<GenObjectSearch> Objs
        {
            get
            {
                return _objs;
            }

            set
            {
                _objs = value;
            }
        }
    }
}
