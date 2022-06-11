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
    /// Logika interakcji dla klasy AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja odpowiadająca za naciśnięcie przycisku "Login"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Stworzenie nowego pracownika i pobranie danych z GUI.
            Employee employee = new Employee();
            
            employee.Name           = TxtName.Text;
            employee.SureName       = TxtSureName.Text;
            employee.PESEL          = TxtPESEL.Text;
            employee.City           = TxtCity.Text;
            employee.Street         = TxtStreet.Text;
            employee.Salary         = int.Parse(TxtPayment.Text);
            employee.DriverLivence  = ConvertBool((bool)ChckB.IsChecked);
            employee.High           = ConvertBool((bool)ChckHeight.IsChecked);
            employee.Sep            = ConvertBool((bool)ChckSEP.IsChecked);
            employee.PhoneNumber    = TxtPhoneNumber.Text;
            employee.Seniority      = int.Parse(TxtSeniority.Text);
            employee.Contract       = CbContract.Text;

            AddEmployeeToDB(employee); //Dodanie pracownika do bazy danych.
            Close();
        }



        /// <summary>
        /// Metoda dodająca pracownika do bazy danych.
        /// Przyjmuje obiekt klasy Employee.
        /// </summary>
        /// <param name="employee"></param>
        private void AddEmployeeToDB(Employee employee)
        {
            try
            {
                w64096Entities database = new w64096Entities(); // Utworzenie instancji bazy danych.
                

                if (!IsEmployeeExist(employee)) // Sprawdzenie czy istnieje już taki pracownik.
                {
                    //Jeśli nie istnieje w bazie danych taki sam pracownik, to następuje dodanie go oraz
                    //wyświetlenie odpowiedniego komunikatu.
                    database.Employee.Add(employee);
                    database.SaveChanges();
                    string tekst = $"Pracownik {employee.Name} {employee.SureName} dodany do rejestru.";
                    MessageBoxImage image = MessageBoxImage.Information;
                    MessageBoxButton button = MessageBoxButton.OK;

                    MessageBox.Show(tekst, "Informacja", button, image);
                }
                
                
            }
            catch(Exception ex)
            {
                //Obsługa wyjątku. //TODO
                string error = ex.ToString();
                MessageBox.Show(error);
                
            }
            
        }

        /// <summary>
        /// Metoda sprawdzająca, czy w bazie danych istnieje już taki sam rekord.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool IsEmployeeExist(Employee employee)
        {
            w64096Entities database = new w64096Entities(); // Utworzenie instancji bazy danych.
            List<Employee> _employeesList = database.Employee.ToList(); // Pobranie listy pracowników z bazdy danych.
            bool _return = false;


            //Sprawdzenie po identyfikatorze PESEL, czy istnieje już taki pracownik.
            foreach(var _employee in _employeesList)
            {
                if (_employee.PESEL.Equals(employee.PESEL))
                {
                    _return = true;
                }
            }

            return _return;
        }

        /// <summary>
        /// Metoda konwertująca bool na int zapisywany w bazie.
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns>Wartość int do bazy danych</returns>
        private static int ConvertBool(bool isChecked)
        {
            return isChecked ? 1 : 0;
        }

        /// <summary>
        /// Metoda obsługująca naciśnięcie przycisku "Cancel"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
