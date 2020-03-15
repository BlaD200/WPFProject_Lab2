using System;
using System.Threading.Tasks;
using System.Windows;
using WPFProject_Lab2.Model;
using WPFProject_Lab2.Tools;
using WPFProject_Lab2.Tools.Managers;
using WPFProject_Lab2.Tools.MVVM;

namespace WPFProject_Lab2.ViewModels
{
    class PersonViewModel : BaseViewModel
    {
        #region Fields

        private Person _person;

        private String _name;
        private String _surname;
        private String _eMail;
        private DateTime? _birthday;

        private RelayCommand<object> _processPersonCommand;

        #endregion


        #region Properties

        public String Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public String Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public String Email
        {
            get => _eMail;
            set
            {
                _eMail = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private bool CanExecuteCommand()
        {
            return Birthday != null && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) &&
                   !string.IsNullOrEmpty(Email);
        }


        public RelayCommand<object> ProceedPersonCommand
        {
            get
            {
                return _processPersonCommand ??= new RelayCommand<object>(
                    ProceedImplementation, o => CanExecuteCommand());
            }
        }


        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                if (Birthday > DateTime.Today)
                {
                    MessageBox.Show("I don't think, Time machine had been invented...", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                else if (Birthday != null)
                {
                    if (Birthday?.Day == DateTime.Today.Day && Birthday?.Month == DateTime.Today.Month)
                        MessageBox.Show("Happy Birthday, my dear friend!🎊🎇🎇🎉🎉🎁🎁");
                    _person = new Person(Name, Surname, Email, Birthday);
                    String info =
                        $"Name: {_person.Name}\nSurname: {_person.Surname}\nEmail: {_person.Email}\nBirthday: {_person.Birthday}\n" +
                        $"IsAdult: {_person.IsAdult}\nSunSign: {_person.SunSign}\nChineseSign: {_person.ChineseSign}\nIsBirthday: {_person.IsBirthday}";
                    MessageBox.Show(info, "Info", MessageBoxButton.OK);
                }
            });
            LoaderManager.Instance.HideLoader();
        }
    }
}