using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorozCsharp2.Models
{
    class User
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdayDate;
        private string _birthday;
        private string _age;
        private string _adult;
        private string _westernZodiac;
        private string _chineseZodiac;
        private string _sunZodiac;

       public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set { _birthdayDate = value; }
        }


        public string Birthday
        {
            get { return _birthday; }
            set
            {   _birthday = value; }
        }

        public string Adult
        {
            get { return _adult; }
            set
            { _adult = value; }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set { _westernZodiac = value; }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value; }
        }

        public string SunZodiac
        {
            get { return _sunZodiac; }
            set { _sunZodiac = value; }
        }
    }
}
