namespace TFProjectAPI.Client.Models
{
    public class MusicType
    {
        private int _id;
        private string _name;

        public MusicType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MusicType()
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
