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
            TopDataGrid.ItemsSource = PersonCollectionData();
            TerrasDataGrid.ItemsSource = BezoekerData();
        }

        // fill TopdataGrid with data
        private ObservableCollection<Person> PersonCollectionData()
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

        private ObservableCollection<Person> BezoekerData()
        {
            ObservableCollection<Person> BezoekerList = new ObservableCollection<Person>();

            // no DateTime Mentioned because it is left empty at start
            BezoekerList.Add(new Person()
            {
                ID = 11,
                Name = "Donald Trump",
                From = "New York City",
                Household = 4,
                LastVisited = DateTime.Now
            });

            return BezoekerList;
        }

        // maak globals om "controlechecks" uit te voeren om te controleren of mensen naar het terras mogen
        // 
        // Controlechecks:
        // check dezelfde bezoeker mag niet meerdere keren aan een lijst worden toegevoegd
        // check maximaal 4 op Terras
        // check maximaal 2 huishoudens
        // check pas toegestaan op terras als iedereen behalve jij is geweest, behalve de eerste keer




        // voeg Bezoeker toe aan locatie
        // Geef LastVisited een tijdstip
        // update datagrid met nieuw tijdstip
        // error handling
        private void NaarTerras(object sender, RoutedEventArgs e)
        {
            // select selected item
            foreach (object o in TopDataGrid.SelectedItems)
            {
                try
                {
                    var bezoeker = o as Person;

                    for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
                    {
                        bezoeker.LastVisited = DateTime.Now;
                    }

                    // Oude Manier
                    //TerrasDataGrid.Items.Add(bezoeker);

                    // voegt niks toe aan Terras?
                    BezoekerData().Add(bezoeker);

                    // Refresh Veranderde items zodat Date correct word weergeven
                    TopDataGrid.Items.Refresh();
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

            foreach (object o in TerrasDataGrid.SelectedItems)
            {
                try
                {
                    var bezoeker = o as Person;

                    //TerrasDataGrid.Items.Remove(bezoeker);

                    BezoekerData().Remove(bezoeker);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }

            }

        }

        // Leegt het volledige Terras van alle bezoekers
        // selecteer alle items
        // Leeg volledig Terras
        private void LeegTerras(object sender, RoutedEventArgs e)
        {
            try
            {
                //TerrasDataGrid.Items.Clear();
                BezoekerData().Clear();
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