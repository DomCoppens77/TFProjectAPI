namespace TFProjectAPI.Client.Models
{
    public class MusicFormat
    {
        private int _id;
        private string _name;

        public MusicFormat(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MusicFormat()
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
