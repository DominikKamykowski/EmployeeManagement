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
            TxtName.Text = employee.Name;
            TxtSureName.Text = employee.SureName;
            TxtCity.Text = employee.City;
            TxtStreet.Text = employee.Street;
            TxtPESEL.Text = employee.PESEL;
            TxtPhoneNumber.Text = employee.PhoneNumber;
            TxtPayment.Text = employee.Salary.ToString();
            TxtSeniority.Text = employee.Seniority.ToString();

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
                result.Salary = int.Parse(TxtPayment.Text);
                database.SaveChanges();
                //Messagebox
            }
            Close();
        }
    }
}
