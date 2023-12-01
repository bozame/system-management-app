using enyoi_project.Mobile.MVVM.Models;
using enyoi_project.Mobile.Responses;
using enyoi_project.Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace enyoi_project.Mobile.MVVM.Viewmodels
{
    public class CreatePersonViewModel : INotifyPropertyChanged
    {

        private string _document;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phone;
        private string _email;
        private bool _isEnabled;
        private bool _isRunning;
        private readonly IApiServices _apiServices;

        public CreatePersonViewModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
        }

        public string Document
        {
            get { return _document; }
            set
            {
                if (_document != value)
                {
                    _document = value;
                    OnPropertyChanged(nameof(Document));
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        public ICommand SavePersonCommand => new Command(async () => await ExecuteSavePersonCommand());

        public IApiServices ApiService { get; }

        private async Task ExecuteSavePersonCommand()
        {
            bool isValid = await ValidateDateAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet.", "Aceptar");
                return;
            }

            Person person = new Person
            {
                Document = Document,
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                Phone = Phone,
                Email = Email,
            };

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiServices.PostAsync(url, "/api", "/People", person);
            IsRunning = false;
            IsEnabled = true;

            if(!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return
            }
        }

        private async Task<bool> ValidateDateAsync()
        {
            if (string.IsNullOrEmpty(Document))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un documento.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un nombre.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un apellido.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Address))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar una dirección.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Phone))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un número de teléfono.", "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debes ingresar un email.", "Aceptar");
                return false;
            }

            return true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
