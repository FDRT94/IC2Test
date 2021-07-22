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
            TopDataGrid.ItemsSource = LoadCollectionData();
        }


        // fill TopdataGrid with data
        private ObservableCollection<Person> LoadCollectionData()
        {
            ObservableCollection<Person> PersonList = new ObservableCollection<Person>();

            // no DateTime Mentioned because it is left empty at start
            PersonList.Add(new Person()
            {
                ID = 1,
                Name = "Mark Rutte",
                From = "Den Haag",
                Household = 1,
                LastVisited = DateTime.Now
            });


            PersonList.Add(new Person()
            {
                ID = 2,
                Name = "Geert Wilders",
                From = "Venlo",
                Household = 1,
            });

            PersonList.Add(new Person()
            {
                ID = 3,
                Name = "Wopke Hoekstra",
                From = "Bennekom",
                Household = 1,
            });

            PersonList.Add(new Person()
            {
                ID = 4,
                Name = "Willem van Alexander",
                From = "Den Haag",
                Household = 1,
            });

            PersonList.Add(new Person()
            {
                ID = 5,
                Name = "Jane Doe",
                From = "Amsterdam",
                Household = 2,
            });

            PersonList.Add(new Person()
            {
                ID = 6,
                Name = "John Doe",
                From = "Amsterdam",
                Household = 2,
            });

            PersonList.Add(new Person()
            {
                ID = 7,
                Name = "Denzel Dumfries",
                From = "Groningen",
                Household = 3,
            });

            PersonList.Add(new Person()
            {
                ID = 8,
                Name = "Matthijs de Ligt",
                From = "Rotterdam",
                Household = 3,
            });

            PersonList.Add(new Person()
            {
                ID = 9,
                Name = "Donyell Malen",
                From = "Amsterdam",
                Household = 3,
            });

            PersonList.Add(new Person()
            {
                ID = 10,
                Name = "Marten de Roon",
                From = "Friesland",
                Household = 3,
            });

            return PersonList;
        }

        // Terras Regels

        // Terras Options

        // selecteer item dat verplaatst moet worden
        // check of bezoeker mag worden toegevoegd aan het Terras


        // Controlechecks:
        // check dezelfde bezoeker mag niet meerdere keren aan een lijst worden toegevoegd
        // check maximaal 4 op Terras
        // check maximaal 2 huishoudens
        // check pas toegestaan op terras als iedereen behalve jij is geweest, behalve de eerste keer


        // voeg Bezoeker toe aan locatie
        // Geef LastVisited een Waarde
        // error handling
        private void NaarTerras(object sender, RoutedEventArgs e)
        {


            // select selected item
            foreach (object o in TopDataGrid.SelectedItems)
            {
                try
                {
                    var bezoeker = o as Person;

                    TerrasDataGrid.Items.Add(bezoeker);

                    for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
                    {
                        bezoeker.LastVisited = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }

            


        }


        // selecteer bezoeker
        // verwijder bezoeker vanuit TerrasDatagrid
        // error Handling
        private void NaarHuis(object sender, RoutedEventArgs e)
        {

            //  foreach (object o in TopDataGrid.SelectedItems)

            //var bezoeker = o as Person;

            //TerrasDataGrid.Items.Add(bezoeker);

            //for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
            //{
            //    bezoeker.LastVisited = DateTime.Now;
            //}

            //var bezoeker = o as Person;

            //for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
            //{
            //    bezoeker.LastVisited = DateTime.Now;
            //}

            //try
            //{
            //    foreach (object o in TerrasDataGrid.SelectedItems)
            //{
            //        TerrasDataGrid.SelectedItem.Remove(o);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            //    throw;
            //}
            

        }

        // Leegt het volledige Terras van alle bezoekers
        // selecteer alle items
        // Leeg volledig Terras
        private void LeegTerras(object sender, RoutedEventArgs e)
        {
            // select alle items item
            try
            {
                TerrasDataGrid.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
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
    }
}
