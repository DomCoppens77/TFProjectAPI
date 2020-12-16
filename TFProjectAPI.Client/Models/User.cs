using System;

namespace TFProjectAPI.Client.Models
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _passwd;
        private string _secretAnswer;
        private bool _active;
        private int _status;
        private int _connectionCount;
        private DateTime _connectionLast;
        private string _avatar;

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string email, string passwd, bool active, int status, int connectionCount, DateTime connectionLast, string secretAnswer, string avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Passwd = passwd;
            SecretAnswer = secretAnswer;
            Active = active;
            Status = status;
            ConnectionCount = connectionCount;
            ConnectionLast = connectionLast;
            Avatar = avatar;
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

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Passwd
        {
            get
            {
                return _passwd;
            }

            set
            {
                _passwd = value;
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
            }
        }

        public int Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public int ConnectionCount
        {
            get
            {
                return _connectionCount;
            }

            set
            {
                _connectionCount = value;
            }
        }

        public DateTime ConnectionLast
        {
            get
            {
                return _connectionLast;
            }

            set
            {
                _connectionLast = value;
            }
        }


        public string SecretAnswer
        {
            get
            {
                return _secretAnswer;
            }

            set
            {
                _secretAnswer = value;
            }
        }

        public string Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar = value;
            }
        }
    }
}
