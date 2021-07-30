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

        // Huishouden Count
        private int nHHOpTerras = 0;

        // HuisHouden ID
        private int TempHouseHoldID;

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
                Name = "Mariette Rutten",
                From = "Den Haag",
                Household = 1,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 3,
                Name = "Dick van Kooten",
                From = "Den Haag",
                Household = 2,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 4,
                Name = "Kees Kleijn",
                From = "Den Haag",
                Household = 3,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 5,
                Name = "Frank de Raadt",
                From = "Hoogvliet",
                Household = 4,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 6,
                Name = "John Doe",
                From = "Den Haag",
                Household = 5,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 7,
                Name = "Jane Doe",
                From = "Den Haag",
                Household = 5,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 8,
                Name = "Johannes Doe",
                From = "Den Haag",
                Household = 5,
            });

            PersonCollectionData.Add(new Person()
            {
                ID = 9,
                Name = "Janna Doe",
                From = "Den Haag",
                Household = 5,
            });

            TopDataGrid.ItemsSource = PersonCollectionData;
        }


        // Alle Controlechecks zijn verwerkt in de NaarTerras Functie
        // max 4 personen op Terras
        // hetzelfde object mag niet meerdere keren worden toegevoegd
        // max 2 huishoudens op het Terras
        // Controleren op Datum

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
                    if (nPersonenOpTerras >= 4)
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

                    // aantal huishoudens op Terras Tracker

                    if (BezoekerData.Count == 0)
                    {
                        // verhoog huishouden count met 1
                        nHHOpTerras++;

                        // set temp TempHouseHoldID to bezoeker.household e.g. 5
                        TempHouseHoldID = bezoeker.Household;
                    }
                    else if (BezoekerData.Count == 1)
                    {
                        //controlleer of nieuw toegoevoegde persoon van het zelfde huishouden vandaan komt.
                        if (bezoeker.Household == TempHouseHoldID)
                        {
                            // nHHOpTerras blijft gelijk dus eigelijk veranderd er niks
                            // TempHouseHoldID blijft ook gelijk dus hier hoeft eigelijk ook niks mee te gebeuren
                        }
                        else if (TempHouseHoldID != bezoeker.Household)
                        {
                            // verhoog huishouden count naar 2 
                            nHHOpTerras++;
                        }
                    }
                    else if (BezoekerData.Count == 2)
                    {
                        if (nHHOpTerras == 2)
                        {
                            MessageBox.Show("Teveel Huishoudens op het Terras", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        else
                        //controlleer of nieuw toegoevoegde persoon van het zelfde huishouden vandaan komt.
                        if (bezoeker.Household == TempHouseHoldID)
                        {
                            // nHHOpTerras blijft gelijk dus eigelijk veranderd er niks
                            // TempHouseHoldID blijft ook gelijk dus hier hoeft eigelijk ook niks mee te gebeuren
                        }
                        else if (TempHouseHoldID != bezoeker.Household)
                        {
                            // verhoog huishouden count
                            nHHOpTerras++;
                        }
                    }

                    else if (BezoekerData.Count == 3)
                    {
                        if (nHHOpTerras == 2)
                        {
                            MessageBox.Show("Teveel Huishoudens op het Terras", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        else

                        //controlleer of nieuw toegoevoegde persoon van het zelfde huishouden vandaan komt.
                        if (bezoeker.Household == TempHouseHoldID)
                        {
                            // nHHOpTerras blijft gelijk dus eigelijk veranderd er niks
                            // TempHouseHoldID blijft ook gelijk dus hier hoeft eigelijk ook niks mee te gebeuren
                        }
                        else if (TempHouseHoldID != bezoeker.Household)
                        {
                            // verhoog huishouden count
                            nHHOpTerras++;
                        }
                    }


                    else if (BezoekerData.Count == 4)
                    {
                        if (nHHOpTerras == 2)
                        {
                            MessageBox.Show("Teveel Huishoudens op het Terras", "Heading", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }

                        //controlleer of nieuw toegoevoegde persoon van het zelfde huishouden vandaan komt.
                        if (bezoeker.Household == TempHouseHoldID)
                        {
                            // nHHOpTerras blijft gelijk dus eigelijk veranderd er niks
                            // TempHouseHoldID blijft ook gelijk dus hier hoeft eigelijk ook niks mee te gebeuren
                        }
                        else if (TempHouseHoldID != bezoeker.Household)
                        {
                            // verhoog huishouden count
                            nHHOpTerras++;
                        }
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

                        // increase global count for Persons
                        nPersonenOpTerras++;
                    }
                    else if (bezoeker.LastVisited != null)
                    {
                        var OrderWachtendeDatum = PersonCollectionData.OrderBy(item => item.LastVisited).First();

                        // convert Person object to DateTime Format
                        DateTime? VroegsteWachtendeDatum = OrderWachtendeDatum.LastVisited;

                        int result = DateTime.Compare((DateTime)bezoeker.LastVisited, (DateTime)VroegsteWachtendeDatum);
                        if (result <= 0)
                        {
                            for (int i = 0; i < TerrasDataGrid.Items.Count + 1; i++)
                            {
                                bezoeker.LastVisited = DateTime.Now;
                            }

                            BezoekerData.Add(bezoeker);
                            TopDataGrid.Items.Refresh();

                            // increase global count for Persons
                            nPersonenOpTerras++;
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

        // Leegt het volledige Terras van alle bezoekers
        private void LeegTerras(object sender, RoutedEventArgs e)
        {
            try
            {
                BezoekerData.Clear();
                nPersonenOpTerras = 0;
                nHHOpTerras = 0;

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