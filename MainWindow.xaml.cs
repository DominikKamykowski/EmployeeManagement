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
     
        /// <summary>
        /// Konstruktor głównego okna aplikacji.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DatabaseViewInitialize(); // inicjalizacja zobrazowania bazy danych w DataGrid
        }


        /// <summary>
        /// Metoda obsługująca inicjalizację zobrazowania rekordów w bazie danych.
        /// </summary>
        private void DatabaseViewInitialize()
        {
            w64096Entities database = new w64096Entities(); // instancja bazy danych

            List<Employee> pracownicy = database.Employee.ToList();

            ObservableCollection<Employee> obsEmployees = new ObservableCollection<Employee>(pracownicy);

            DGEmployeesData.DataContext = obsEmployees;
            DGEmployeesData.ItemsSource = obsEmployees; // podpięcie bazy danych do widoku z GUI.
        }


        /// <summary>
        /// Medota obsługująca naciśnięcie klawisza dodającego pracownika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWindow = new AddEmployee();
            addEmployeeWindow.Show(); // Otwarcie okna obsługującego dodanie pracownika.
            

        }


        /// <summary>
        /// Funkcja odświeżająca widok DataGrid.
        /// </summary>
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

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = DGEmployeesData.SelectedItem as Employee;
            if (employee != null)
            {
                w64096Entities database = new w64096Entities();
                Employee employeeToEdit = database.Employee.Find(employee.ID);
                EditEmployee edit = new EditEmployee(employeeToEdit);
                edit.Show();

            }
            
            }
        }

    }

