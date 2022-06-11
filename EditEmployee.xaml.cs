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
    /// Logika interakcji dla klasy EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public Employee EmployeeState { get; set; } //Właściwość pracownika - w celu edycji.


        /// <summary>
        /// Konstruktor klasy. Wypełnia podstawową formatkę z parametru w celu edycji.
        /// </summary>
        /// <param name="employee"></param>
        public EditEmployee(Employee employee)
        {
            InitializeComponent();

            EmployeeState = employee;

            FillFormula(employee);
        }


        /// <summary>
        /// Metoda wypełniająca arkusz do edycji pracownika.
        /// </summary>
        /// <param name="employee"></param>
        private void FillFormula(Employee employee)
        {
            TxtName.Text        = employee.Name;
            TxtSureName.Text    = employee.SureName;
            TxtCity.Text        = employee.City;
            TxtStreet.Text      = employee.Street;
            TxtPESEL.Text       = employee.PESEL;
            TxtPhoneNumber.Text = employee.PhoneNumber;
            TxtPayment.Text     = employee.Salary.ToString();
            TxtSeniority.Text   = employee.Seniority.ToString();

            switch (employee.Contract)
            {
                case "Umowa o pracę":
                    CbContract.SelectedIndex = 0;
                    break;
                case "Umowa o dzieło":
                    CbContract.SelectedIndex = 1;
                    break;
                case "Umowa zlecenie":
                    CbContract.SelectedIndex = 2;
                    break;
                case "Kontrakt":
                    CbContract.SelectedIndex = 3;
                    break;
                default:
                    break;
            }



            if (employee.High == 1)
            {
                ChckHeight.IsChecked = true;
            }
            else
            {
                ChckHeight.IsChecked = false;
            }

            if (employee.Sep == 1)
            {
                ChckSEP.IsChecked = true;
            }
            else
            {
                ChckSEP.IsChecked = false;
            }

            if (employee.DriverLivence == 1)
            {
                ChckB.IsChecked = true;
            }
            else
            {
                ChckB.IsChecked = false;
            }


        }


        /// <summary>
        /// Metoda obsługująca naciśnięcie przycisku "Cancel". Zamyka okno i anuluje edycję pracownika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Metoda obsługująca naciśnięcie przycisku "Save".
        /// Zapisuje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            w64096Entities database = new w64096Entities();

            var result = database.Employee.SingleOrDefault(x => x.ID == EmployeeState.ID);
            if (result != null)
            {
                SaveEmployee(result); // zapisanie pracownika


                //Wyświetlenie Messagebox upewniającego użytkownika o zapisie danych do bazy.
                string context = "Czy na pewno chcesz zapisać parametry?";
                string title = "Edycja Pracownika";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage image_ = MessageBoxImage.Question;
                MessageBoxResult MsgBoxResult = MessageBoxResult.No;
                MessageBoxResult MsgResult = MessageBox.Show(context, title, button, image_, MsgBoxResult);

                switch (MsgResult) // Wybranie ekcji od użytkownika
                {
                    case MessageBoxResult.Yes: // Jeśli użytkownik wybierze "Tak" to zmiany są zapisywane.
                        database.SaveChanges(); // Zapisanie zmian w bazie danych.
                        break;

                    case MessageBoxResult.No: // Jeśli użytkownik wybierze "Nie" to zmiany są odrzucane.
                        Close(); // Zamknięcie okna edycji.
                        break;

                    default:
                        break;
                }

            }
            Close();
        }


        /// <summary>
        /// Metoda obsługująca zapis parametrów pracownika.
        /// </summary>
        /// <param name="result"></param>
        private void SaveEmployee(Employee result)
        {
            result.Name             = TxtName.Text;
            result.SureName         = TxtSureName.Text;
            result.PESEL            = TxtPESEL.Text;
            result.City             = TxtCity.Text;
            result.Street           = TxtStreet.Text;
            result.Salary           = int.Parse(TxtPayment.Text);
            result.DriverLivence    = ConvertBool((bool)ChckB.IsChecked);
            result.High             = ConvertBool((bool)ChckHeight.IsChecked);
            result.Sep              = ConvertBool((bool)ChckSEP.IsChecked);
            result.PhoneNumber      = TxtPhoneNumber.Text;
            result.Seniority        = int.Parse(TxtSeniority.Text);
            result.Contract         = CbContract.Text;

        }


        /// <summary>
        /// Metoda konwertująca zaznaczenie CheckBox'a na wartość int.
        /// </summary>
        /// <param name="isChecked">Parametr typu bool przekazywany do zmiany.
        /// true = 1, false = 0 </param>
        /// <returns>Odpowiednia liczba typu int: 0 lub 1</returns>
        private int? ConvertBool(bool isChecked)
        {
            return isChecked ? 1 : 0;
        }
    }
}
