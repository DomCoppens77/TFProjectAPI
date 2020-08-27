namespace TFProjectAPI.Client.Models
{
    public class GeneralType
    {

        private int _id;
        private string _name;

        public GeneralType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public GeneralType()
        {

        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }


    }
}
