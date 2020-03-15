using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Navigation;
using WPFProject_Lab2.Tools.Exceptions;

namespace WPFProject_Lab2.Model
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthday;

        private int _age;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        internal string Name
        {
            get => _name;
            set
            {
                _name = value;
                // OnPro
            }
        }

        internal string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                // OnPro
            }
        }

        internal string Email
        {
            get => _email;
            set
            {
                _email = value;
                // OnPro
            }
        }

        internal DateTime? Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                // OnPro
                if (value != null)
                {
                    var today = DateTime.Today;
                    var age = (today.Year - _birthday.Value.Year);
                    // Go back to the year the person was born in case of a leap year
                    if (_birthday?.Date > today.AddYears(-age)) age--;
                    _age = age;
                }
            }
        }

        internal bool IsAdult
        {
            get => _isAdult;
            private set { }
        }

        internal String SunSign
        {
            get => _sunSign;
            private set { }
        }

        internal String ChineseSign
        {
            get => _chineseSign;
            private set { }
        }

        internal bool IsBirthday
        {
            get => _isBirthday;
            private set { }
        }

        private String GetZodiac(DateTime date)
        {
            int month = date.Month;
            var day = date.Day;
            if (month == 12)
            {
                return day < 22 ? "Sagittarius" : "Capricorn";
            }

            else if (month == 1)
            {
                return day < 20 ? "Capricorn" : "Aquarius";
            }

            else if (month == 2)
            {
                return day < 19 ? "Aquarius" : "Pisces";
            }

            else if (month == 3)
            {
                return day < 21 ? "Pisces" : "Aries";
            }
            else if (month == 4)
            {
                return day < 20 ? "Aries" : "Taurus";
            }

            else if (month == 5)
            {
                return day < 21 ? "Taurus" : "Gemini";
            }

            else if (month == 6)
            {
                return day < 21 ? "Gemini" : "Cancer";
            }

            else if (month == 7)
            {
                return day < 23 ? "Cancer" : "Leo";
            }

            else if (month == 8)
            {
                return day < 23 ? "Leo" : "Virgo";
            }

            else if (month == 9)
            {
                return day < 23 ? "Virgo" : "Libra";
            }

            else if (month == 10)
            {
                return day < 23 ? "Libra" : "Scorpio";
            }

            else if (month == 11)
            {
                return day < 22 ? "Scorpio" : "Sagittarius";
            }
            else
            {
                MessageBox.Show("Incorrect date of birth!");
                return "";
            }
        }

        private string GetChineseZodiac(DateTime date)
        {
            double remainder = date.Year / 12.0;
            remainder %= (int) remainder;
            int sign = (int) Math.Round(remainder * 12);

            String[] years =
            {
                "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep",
            };

            return years[sign];
        }

        public Person(string name, string surname, string email = "", DateTime? birthday = null)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;

            if (!Regex.IsMatch(Name, "\\D"))
            {
                throw new InvalidNameException("Name cannot contains digits.");
            }

            if (!Regex.IsMatch(Surname, "\\D"))
            {
                throw new InvalidNameException("Surname cannot contains digits.");
            }

            if (Birthday > DateTime.Today)
            {
                throw new FutureBirthdayException("Birthday cannot be at the future.");
            }

            if (_age > 135)
            {
                throw new PastBirthdayException("Birthday cannot be so far in past.");
            }

            var email_pattern =
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (!Regex.IsMatch(Email, email_pattern, RegexOptions.IgnoreCase))
            {
                throw new InvalidEmailException($"Invalid email: \"{Email}\".");
            }

            _isAdult = _age >= 18;
            _isBirthday = Birthday?.Day == DateTime.Today.Day && Birthday?.Month == DateTime.Today.Month;
            _sunSign = GetZodiac(Birthday.Value);
            _chineseSign = GetChineseZodiac(Birthday.Value);
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = null;

            _isAdult = _age >= 18;
            _isBirthday = Birthday?.Day == DateTime.Today.Day && Birthday?.Month == DateTime.Today.Month;
            _sunSign = GetZodiac(Birthday.Value);
            _chineseSign = GetChineseZodiac(Birthday.Value);
        }

        public Person(string name, string surname, DateTime? birthday)
        {
            Name = name;
            Surname = surname;
            Email = "";
            Birthday = birthday;

            _isAdult = _age >= 18;
            _isBirthday = Birthday?.Day == DateTime.Today.Day && Birthday?.Month == DateTime.Today.Month;
            _sunSign = GetZodiac(Birthday.Value);
            _chineseSign = GetChineseZodiac(Birthday.Value);
        }
    }
}