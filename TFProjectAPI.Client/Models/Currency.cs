namespace TFProjectAPI.Client.Models
{
    public class Currency
    {
        private string _curr, _desc;

        public Currency(string curr, string desc)
        {
            Curr = curr;
            Desc = desc;
        }
        public Currency()
        {

        }
        public string Curr
        {
            get
            {
                return _curr;
            }

            set
            {
                _curr = value;
            }
        }

        public string Desc
        {
            get
            {
                return _desc;
            }

            set
            {
                _desc = value;
            }
        }
    }
}
