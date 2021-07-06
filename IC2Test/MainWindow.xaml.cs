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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IC2Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Student> stuList = new List<Student>();
            stuList.Add(new Student()
            {
                Name = "Jacob",
                Age = 29,
                City = "London",
                Dob = new DateTime(1984, 5, 26)
            });
            try
            {
                MessageBox.Show(stuList[1].Name, "Kopje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Error: " + ex2.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        } // Button_Click
        private void OnLoaded(object sender, RoutedEventArgs e)
        { 
        } // Onloaded
    }// class Mainwindow
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public DateTime Dob { get; set; }
    }
}
