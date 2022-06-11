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

namespace EmployeeManagement
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string Login { get; set; }
        private string Password { get; set; }

        private ushort BadLoginTryNumber = 0;
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja odpowiadająca za naciśnięcie przycisku "Cancel"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Funkcja odpowiadająca za naciśnięcie przycisku "Login"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginFunction();
        }


        /// <summary>
        /// Funkcja odpowiadająca za naciśnięcie przycisku Enter w polu wpisywania hasła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginFunction();
            }
        }


        /// <summary>
        /// Funkcja odpowiadająca za funkcjonalność zalogowania się.
        /// </summary>
        private void LoginFunction()
        {
            if (TxtLogin.Text.Equals("Login") && TxtPassword.Password.Equals("Password")) // sprawdzenie poprawności danych logowania
            {
                //Jeśli poprawne to wyświetla okno główne oraz zamyka okno logowania
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();

            }
            else
            {
                //Jeśli błędne to wyświetla MessageBox z błędem oraz inkrementuje licznik błędnych prób logowania oraz po 3 błędnych próbach zamyka aplikację
                MessageBox.Show("Wrong Login or Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                BadLoginTryNumber++;

                if (BadLoginTryNumber == 3) // Przy 3 błędnęj próbie zamyka aplikację
                {
                    Close();
                }
            }
        }
    }
}
