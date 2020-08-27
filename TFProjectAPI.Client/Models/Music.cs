using System;

namespace TFProjectAPI.Client.Models
{
    public class Music : DomObj
    {
		private string _band;
		private string _title;
		private int _yEAR;
		private string _tRACKS;
		private int _nbCDs;
		private int _nbDvds;
		private int _nbLps;
		private int _mTypeId;
		private int _formatId;
		private string _serialNbr;
        private string _ctry;

        private string _typeStr, _formatStr;

        public Music(int id, string band, string title, int yEAR, string tRACKS, int nbCDs, int nbDvds, int nbLps, int mTypeId, int formatId, string serialNbr, string ctry,
            string typeStr,string formatStr, 
            float price, string curr, int shopId, DateTime date, int typeId, bool signed, string signedBy, string eAN, string eAN_EXT, string comment1, string comment2, bool onwed) 
            : base (id, price, curr, shopId, date, typeId, signed, signedBy, eAN, eAN_EXT, comment1, comment2, onwed)
        {
            Band = band;
            Title = title;
            YEAR = yEAR;
            TRACKS = tRACKS;
            NbCDs = nbCDs;
            NbDvds = nbDvds;
            NbLps = nbLps;
            MTypeId = mTypeId;
            FormatId = formatId;
            SerialNbr = serialNbr;
            Ctry = ctry;
            TypeStr = typeStr;     // Non DB Field
            FormatStr = formatStr; // Non DB Field
        }
        public Music()
        {
        }

        public string Band
        {
            get
            {
                return _band;
            }

            set
            {
                _band = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public int YEAR
        {
            get
            {
                return _yEAR;
            }

            set
            {
                _yEAR = value;
            }
        }

        public string TRACKS
        {
            get
            {
                return _tRACKS;
            }

            set
            {
                _tRACKS = value;
            }
        }

        public int NbCDs
        {
            get
            {
                return _nbCDs;
            }

            set
            {
                _nbCDs = value;
            }
        }

        public int NbDvds
        {
            get
            {
                return _nbDvds;
            }

            set
            {
                _nbDvds = value;
            }
        }

        public int NbLps
        {
            get
            {
                return _nbLps;
            }

            set
            {
                _nbLps = value;
            }
        }

        public int MTypeId
        {
            get
            {
                return _mTypeId;
            }

            set
            {
                _mTypeId = value;
            }
        }

        public int FormatId
        {
            get
            {
                return _formatId;
            }

            set
            {
                _formatId = value;
            }
        }

        public string SerialNbr
        {
            get
            {
                return _serialNbr;
            }

            set
            {
                _serialNbr = value;
            }
        }

        public string TypeStr
        {
            get
            {
                return _typeStr;
            }

            set
            {
                _typeStr = value;
            }
        }

        public string FormatStr
        {
            get
            {
                return _formatStr;
            }

            set
            {
                _formatStr = value;
            }
        }

        public string Ctry
        {
            get
            {
                return _ctry;
            }

            set
            {
                _ctry = value;
            }
        }
    }
}
