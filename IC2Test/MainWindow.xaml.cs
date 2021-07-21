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
            McDataGrid.ItemsSource = LoadCollectionData();
        }

        // fill dataGrid with data
        private List<Person> LoadCollectionData()
        {
            List<Person> Persons = new List<Person>();

            // no DateTime Mentioned because it is left empty at start
            Persons.Add(new Person()
            {
                ID = 1,
                Name = "Mark Rutte",
                From = "Den Haag",
                Household = 1,
                
            });

            Persons.Add(new Person()
            {
                ID = 2,
                Name = "Geert Wilders",
                From = "Venlo",
                Household = 1,
            });

            Persons.Add(new Person()
            {
                ID = 3,
                Name = "Wopke Hoekstra",
                From = "Bennekom",
                Household = 1,
            });

            Persons.Add(new Person()
            {
                ID = 4,
                Name = "Willem van Alexander",
                From = "Den Haag",
                Household = 1,
            });

            Persons.Add(new Person()
            {
                ID = 5,
                Name = "Jane Doe",
                From = "Amsterdam",
                Household = 2,
            });

            Persons.Add(new Person()
            {
                ID = 6,
                Name = "John Doe",
                From = "Amsterdam",
                Household = 2,
            });

            Persons.Add(new Person()
            {
                ID = 7,
                Name = "Denzel Dumfries",
                From = "Groningen",
                Household = 3,
            });

            Persons.Add(new Person()
            {
                ID = 8,
                Name = "Matthijs de Ligt",
                From = "Rotterdam",
                Household = 3,
            });

            Persons.Add(new Person()
            {
                ID = 9,
                Name = "Donyell Malen",
                From = "Amsterdam",
                Household = 3,
            });

            Persons.Add(new Person()
            {
                ID = 10,
                Name = "Marten de Roon",
                From = "Friesland",
                Household = 3,
            });

            return Persons;
        }


        private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in McDataGrid.SelectedItems)
                try
                {
                    MessageBox.Show((o as Person).Name, "Kopje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error" + ex2.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
        }

        private void btnSelectLast_Click(object sender, RoutedEventArgs e)
        {
            McDataGrid.SelectedIndex = McDataGrid.Items.Count - 1;
        }

        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if ((McDataGrid.SelectedIndex >= 0) && (McDataGrid.SelectedIndex < (McDataGrid.Items.Count - 1)))
                nextIndex = McDataGrid.SelectedIndex + 1;
            McDataGrid.SelectedIndex = nextIndex;
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in McDataGrid.Items)
                McDataGrid.SelectedItems.Add(o);
        }

        // Terras Options
        

        private void btnAddPersonTerras_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world", "Kopje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void btnRemovePersonTerras_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world", "Kopje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void btnRemoveAllTerras_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world", "Kopje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }


        // Person.DateTime has ? because Datetime should be nullable at the start
        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string From { get; set; }
            public int Household { get; set; }
            public DateTime? LastVisited { get; set; }

        }

        private void NaarTerras(object sender, RoutedEventArgs e)
        {

        }
    }
}
