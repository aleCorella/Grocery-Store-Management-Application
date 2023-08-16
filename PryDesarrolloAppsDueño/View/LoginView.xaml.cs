using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PryDesarrolloAppsDueño.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void bnt_Minimize_Click(object sender, RoutedEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }

        private void bnt_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txt_User_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // La expresión regular para permitir solo letras, números y algunos caracteres específicos (por ejemplo, guiones bajos y guiones medios)
            Regex regex = new Regex("[^a-zA-Z0-9_-]");

            // Verificar si el nuevo texto contiene caracteres no permitidos
            if (regex.IsMatch(e.Text))
            {
                e.Handled = true; // Cancelar el evento para evitar que el carácter se agregue al TextBox
            }
            
        }
        private void txt_User_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Space || txt_User.Text.Length>16)
            {
                e.Handled= true;

            }
        }
    }
}
