using Microsoft.Windows.Themes;
using PryDesarrolloAppsDueño.Model;
using PryDesarrolloAppsDueño.Repositories;
using PryDesarrolloAppsDueño.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PryDesarrolloAppsDueño.ViewModel
{
    // La clase LoginViewModel hereda de ViewModelBase, lo que sugiere que ViewModelBase debe ser una clase base que contiene la lógica compartida entre ViewModels.
    public class LoginViewModel : ViewModelBase
    {
        // Variables privadas para almacenar datos relacionados con la vista.
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isVisible = true;
        
        private IUserRepository userRepository;

        // Propiedades públicas para exponer los datos a la vista y permitir la actualización automática de la interfaz de usuario.
        // Estas propiedades utilizan el patrón de NotifyPropertyChanged para notificar a la vista cuando cambian los valores.
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropetyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropetyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropetyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropetyChanged(nameof(IsViewVisible));
            }
        }

        // Comandos que se pueden asociar con acciones en la vista.
        // ICommand es una interfaz que representa un comando que se puede ejecutar.
        // Aquí, los comandos se inicializan en el constructor, pero su lógica de ejecución aún no se ha implementado.
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor de la clase.
        public LoginViewModel()
        {
            // Se inicializan los comandos. LoginCommand se inicializa con métodos ExecuteLoginCommand y CanExecuteLoginCommand.
            // RecoverPasswordCommand se inicializa con un método ExecuteRecoverPassCommand que toma dos parámetros, pero no se les proporciona valor aquí.
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        // Métodos privados que representan la lógica de ejecución para los comandos.
        // En este código, estos métodos arrojan NotImplementedException, lo que indica que aún no se han implementado y deben ser definidos en otro lugar.
        // Los nombres de los métodos sugieren sus propósitos: LoginCommand se ejecuta cuando el usuario inicia sesión, RecoverPasswordCommand se ejecuta cuando el usuario recupera su contraseña.
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if(string.IsNullOrWhiteSpace(Username) || Username.Length<3 || Password==null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AunthenticateUser(new NetworkCredential(Username,Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;

            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        private void ExecuteRecoverPassCommand(string username, string mail)
        {
            throw new NotImplementedException();
        }
    }
}
