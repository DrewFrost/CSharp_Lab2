using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MorozCsharp2.Models;
using MorozCsharp2.Tools;
using MorozCsharp2.Tools.Manager;

namespace MorozCsharp2.ViewModel
{
   internal class UserViewModel:BaseViewModel
   {
        private readonly User _user;
        private string _name = "";
        private string _surname;
        private string _email = "";
        private DateTime _birthdayDate;
        private string _birthday;
        private string _age;
        private string _adult;
        private string _westernZodiac;
        private string _chineseZodiac;
        private string _sunZodiac;


        internal UserViewModel()
        {
           _user = new User();

        }

        #region Command
        private RelayCommand<object> _startCommand;


        #endregion

        #region Properties

        public string Name
        {
            get { return _name ; }
            set
            {
                _name = value;
                OnPropertyChanged();

            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
                OnPropertyChanged();
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public string SunZodiac
        {
            get { return _sunZodiac; }
            set
            {
                _sunZodiac = value;
                OnPropertyChanged();

            }
        }

        public string Adult
        {
            get { return _adult;  }
            set
            {
                _adult = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public RelayCommand<object> StartCommand
        {
            get
            {
               return _startCommand = new RelayCommand<object>(async obj =>
               {

                    LoaderManager.Instance.ShowLoader();
                    await Task.Run(() => Thread.Sleep(2000));
                    LoaderManager.Instance.HideLoader();
                    int userAge = UsersAge();
                    if (userAge <= 0)
                    {
                        MessageBox.Show("You don't even exist yet, don't lie to me");
                        throw new Exception("You're too young");
                    }else if (userAge >= 135)
                    {
                        MessageBox.Show("Go take your pills old man");
                        throw new Exception("You're too old for us");
                    }else
                    {
                        if (BirthdayDate.DayOfYear == DateTime.Today.DayOfYear)
                        {
                            MessageBox.Show("Happy Birthday!");
                        }
                        Name = $"Your surname is {_name}";
                        Surname = $"Your surname is {_surname}";
                        Age = $"You are {userAge.ToString()} years old";
                        Email = (_email != "" ? $"Your email is {_email}": $"You haven't entered email");
                        Adult = isAdult();
                        WesternZodiac = $"Your western zodiac sign is {WesternZodiacSign()}";
                        SunZodiac = $"Your sun zodiac sign is {SunZodiacSign()}";
                        ChineseZodiac = $"You chinese zodiac sign is {ChineseZodiacSign()}";
                    }
                    

                });
            }
        }

       private int UsersAge()
       {
           return DateTime.Today.Year - _birthdayDate.Year -
                  (BirthdayDate.Month > DateTime.Today.Month && BirthdayDate.Day > DateTime.Today.Day ? 1 : 0);
       }


       private string isAdult()
       {
           if (UsersAge() <= 17)
           {
               return $"You are young";
           }

           return $"You are adult";
        }

       private string WesternZodiacSign()
       {
           switch (_birthdayDate.Month)
           {
               case 1:
                   return _birthdayDate.Day <= 19 ? "Capricorn" : "Aquarius";
               case 2:
                   return _birthdayDate.Day <= 17 ? "Aquarius" : "Pisces";
               case 3:
                   return _birthdayDate.Day <= 19 ? "Pisces" : "Aries";
               case 4:
                   return _birthdayDate.Day <= 19 ? "Aries" : "Taurus";
               case 5:
                   return _birthdayDate.Day <= 20 ? "Taurus" : "Gemini";
               case 6:
                   return _birthdayDate.Day <= 20 ? "Gemini" : "Cancer";
               case 7:
                   return _birthdayDate.Day <= 22 ? "Cancer" : "Leo";
               case 8:
                   return _birthdayDate.Day <= 22 ? "Leo" : "Virgo";
               case 9:
                   return _birthdayDate.Day <= 22 ? "Virgo" : "Libra";
               case 10:
                   return _birthdayDate.Day <= 22 ? "Libra" : "Scorpio";
               case 11:
                   return _birthdayDate.Day <= 21 ? "Scorpio" : "Sagittarius";
               case 12:
                   return _birthdayDate.Day <= 21 ? "Sagittarius" : "Capricorn";
               default:
                   throw new ArgumentException("We haven't invented western Zodiac sign for you yet!");
           }
       }

       private string SunZodiacSign()
       {
           switch (_birthdayDate.Month)
           {
               case 1:
                   return _birthdayDate.Day <= 19 ? "Saturn" : "Uranus";
               case 2:
                   return _birthdayDate.Day <= 17 ? "Uranus" : "Neptune";
               case 3:
                   return _birthdayDate.Day <= 19 ? "Neptune" : "Mars";
               case 4:
                   return _birthdayDate.Day <= 19 ? "Mars" : "Venus";
               case 5:
                   return _birthdayDate.Day <= 20 ? "Venus" : "Mercury";
               case 6:
                   return _birthdayDate.Day <= 20 ? "Mercury" : "Luna";
               case 7:
                   return _birthdayDate.Day <= 22 ? "Luna" : "Sun";
               case 8:
                   return _birthdayDate.Day <= 22 ? "Sun" : "Mercury";
               case 9:
                   return _birthdayDate.Day <= 22 ? "Mercury" : "Venus";
               case 10:
                   return _birthdayDate.Day <= 22 ? "Venus" : "Pluto";
               case 11:
                   return _birthdayDate.Day <= 21 ? "Pluto" : "Jupiter";
               case 12:
                   return _birthdayDate.Day <= 21 ? "Jupiter" : "Saturn";
               default:
                   throw new ArgumentException("Your planet wasn't found");
           }
       }

       private string ChineseZodiacSign()
       {
           switch ((_birthdayDate.Year -3)%12)
           {
                case 1:
                    return _chineseZodiac = "Rat";
                case 2:
                    return _chineseZodiac = "Ox";
                case 3:
                    return _chineseZodiac = "Tiger";
                case 4:
                    return _chineseZodiac = "Rabbit";
                case 5:
                    return _chineseZodiac = "Dragon";
                case 6:
                    return _chineseZodiac = "Snake";
                case 7:
                    return _chineseZodiac = "Horse";
                case 8:
                    return _chineseZodiac = "Goat";
                case 9:
                    return _chineseZodiac = "Monkey";
                case 10:
                    return _chineseZodiac = "Rooster";
                case 11:
                    return _chineseZodiac = "Dog";
                case 12:
                    return _chineseZodiac = "Pig";
                default:
                    throw new ArgumentException("Your chinese zodiac wasn't found");
            }
       }
    }
}

