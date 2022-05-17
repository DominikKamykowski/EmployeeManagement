using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatabaseViewInitialize();
        }

        private void DatabaseViewInitialize()
        {
            w64096Entities database = new w64096Entities();

            List<Employee> pracownicy = database.Employee.ToList();

            ObservableCollection<Employee> obsEmployees = new ObservableCollection<Employee>(pracownicy);

            DGEmployeesData.DataContext = obsEmployees;
            DGEmployeesData.ItemsSource = obsEmployees;
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWindow = new AddEmployee();
            addEmployeeWindow.Show();

        }

        public void DataGridRefresh()
        {
            DGEmployeesData.ItemsSource = null;
            DatabaseViewInitialize();
        }

        private void BtnRefreshDataGridView_Click(object sender, RoutedEventArgs e)
        {
            DataGridRefresh();
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = DGEmployeesData.SelectedItem as Employee;
            if (employee != null)
            {
                w64096Entities database = new w64096Entities();
                Employee delete = database.Employee.Find(employee.ID);
                
                database.Employee.Remove(delete);
                database.SaveChanges();

                DataGridRefresh();
            }
        }
    }
}
