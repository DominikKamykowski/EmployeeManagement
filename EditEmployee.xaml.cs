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
        public Employee EmployeeState { get; set; }

        public EditEmployee(Employee employee)
        {
            InitializeComponent();

            EmployeeState = employee;

            FillFormula(employee);
        }

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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            w64096Entities database = new w64096Entities();

            var result = database.Employee.SingleOrDefault(x => x.ID == EmployeeState.ID);
            if (result != null)
            {
                SaveEmployee(result);


                //Messagebox
                string context = "Czy na pewno chcesz zapisać parametry?";
                string title = "Edycja Pracownika";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage image_ = MessageBoxImage.Question;
                MessageBoxResult MsgBoxResult = MessageBoxResult.No;
                MessageBoxResult MsgResult = MessageBox.Show(context,title ,button, image_,MsgBoxResult);
                switch (MsgResult)
                {
                    case MessageBoxResult.Yes:
                        database.SaveChanges();
                        break;

                    case MessageBoxResult.No:
                        Close();
                        break;

                    default:
                        break;
                }

            }
            Close();
        }

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

        private int? ConvertBool(bool isChecked)
        {
            return isChecked ? 1 : 0;
        }
    }
}
