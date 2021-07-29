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

        private ObservableCollection<Person> PersonCollectionData;
        private ObservableCollection<Person> BezoekerData;
        private int nPersonenOpTerras = 0;
        private int nHHOpTerras = 0;

        public MainWindow()

        {
            InitializeComponent();
            PersonCollectionData = new ObservableCollection<Person>();
            BezoekerData = new ObservableCollection<Person>();

            // fill TopdataGrid with data
            // hoort eigelijk in een aparte method
            PersonCollectionData.Add(new Person()
            {
                ID = 1,
                Name = "Mark Rutte",
                From = "Den Haag",
                Household = 1,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 2,
                Name = "Dick van Kooten",
                From = "Den Haag",
                Household = 2, 
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 3,
                Name = "Kees Kleijn",
                From = "Den Haag",
                Household = 3,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 4,
                Name = "Frank de Raadt",
                From = "Hoogvliet",
                Household = 4,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 5,
                Name = "John Doe",
                From = "Den Haag",
                Household = 5, 
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 6,
                Name = "Jane Doe",
                From = "Den Haag",
                Household = 5,
            });

            TopDataGrid.ItemsSource = PersonCollectionData;
        }

        // voeg Bezoeker toe aan locatie
        // Geef LastVisited een tijdstip
        // update datagrid met nieuw tijdstip
        // error handling
        private void NaarTerras(object sender, RoutedEventArgs e)
        {

            TerrasDataGrid.ItemsSource = BezoekerData;

            foreach (object o in TopDataGrid.SelectedItems)
            {
                try
                {
                    var bezoeker = o as Person;

                    // Control Check max 4 personen
                    if (BezoekerData.Count >= 4)
                    {
                        MessageBox.Show("Terras zit al Vol", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }

                    // check of Persoon al niet op het terras aanwezig is
                    else if (BezoekerData.Contains(bezoeker))
                    {
                        MessageBox.Show("Persoon is al Aanwezig op het Terras", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }


                    

                    // Controlecheck of andere personen naar het terras mogen voordat de persoon word geplaats
                    // Eerst Controleren of een Persoon uberhaupt is geweest
                    // Daarna Controleren of de Persoon naar het Terras mag omdat alle anderen zijn geweest

                    if (bezoeker.LastVisited == null)
                    {
                        for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
                        {
                            bezoeker.LastVisited = DateTime.Now;
                        }

                        BezoekerData.Add(bezoeker);
                        TopDataGrid.Items.Refresh();
                    }
                    else if (bezoeker.LastVisited != null)
                    {
                        var OrderWachtendeDatum = PersonCollectionData.OrderBy(item => item.LastVisited).First();

                        // convert Person object to DateTime Format
                        DateTime? VroegsteWachtendeDatum = OrderWachtendeDatum.LastVisited;

                        int result = DateTime.Compare((DateTime)bezoeker.LastVisited, (DateTime)VroegsteWachtendeDatum);
                        if (result <= 0)
                        {
                            MessageBox.Show("Persoon is Toegevoegd aan het terras", "Heading", MessageBoxButton.OK, MessageBoxImage.Information);
                            for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
                            {
                                bezoeker.LastVisited = DateTime.Now;
                            }

                            BezoekerData.Add(bezoeker);
                            TopDataGrid.Items.Refresh();
                        }
                        else if (result > 0)
                        {
                            MessageBox.Show("Een ander persoon is eerst aan de beurt", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
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
            foreach (object o in TerrasDataGrid.SelectedItems)
            {
                var bezoeker = o as Person;

                try
                {
                    BezoekerData.Remove(bezoeker);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message.ToString(), "", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            }
        }



        // Leegt het volledige Terras van alle bezoekers
        private void LeegTerras(object sender, RoutedEventArgs e)
        {
            try
            {
                BezoekerData.Clear();
                MessageBox.Show("Terras is leeggemaakt", "Heading", MessageBoxButton.OK, MessageBoxImage.Information);
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