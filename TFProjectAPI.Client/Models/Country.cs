namespace TFProjectAPI.Client.Models
{
    public class Country
    {

        private string _iSO;
        private string _ctry;
        private bool _isEU;

        public Country(string iso, string ctry, bool isEU)
        {
            ISO = iso;
            Ctry = ctry;
            IsEU = isEU;
        }

        public Country()
        {

        }

        public string ISO
        {
            get
            {
                return _iSO;
            }

            set
            {
                _iSO = value;
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

        public bool IsEU
        {
            get
            {
                return _isEU;
            }

            set
            {
                _isEU = value;
            }
        }


    }
}
