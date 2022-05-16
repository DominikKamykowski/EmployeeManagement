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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            
            employee.Name = TxtName.Text;
            employee.SureName = TxtSureName.Text;
            employee.PESEL = TxtPESEL.Text;
            employee.City = TxtCity.Text;
            employee.Street = TxtStreet.Text;
            employee.Salary = int.Parse(TxtPayment.Text);
            employee.DriverLivence = ConvertBool((bool)ChckB.IsChecked);
            employee.High = ConvertBool((bool)ChckHeight.IsChecked);
            employee.Sep = ConvertBool((bool)ChckSEP.IsChecked);
            employee.PhoneNumber = TxtPhoneNumber.Text;
            employee.Seniority = int.Parse(TxtSeniority.Text);
            employee.Contract = CbContract.Text;

            AddEmployeeToDB(employee);
        }

        private void AddEmployeeToDB(Employee employee)
        {
            try
            {
                w64096Entities database = new w64096Entities();
                database.Employee.Add(employee);
                database.SaveChanges();
            }
            catch(Exception ex)
            {
                
                
            }
            
        }

        private static int ConvertBool(bool isChecked)
        {
            return isChecked ? 1 : 0;
        }
    }
}
