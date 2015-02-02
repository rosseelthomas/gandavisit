using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace GandaVisit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //dummy
        List<ISpot> spots;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            //Dummy
            spots = new List<ISpot>();
            
            ISpot belfort = new Spot();
            belfort.Naam = "Belfort";
            belfort.ImgLink = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/BelfortGent.jpg/210px-BelfortGent.jpg";
            belfort.Description = "Het belfort van Gent is een 95-meter hoge belforttoren in het centrum van de Belgische stad Gent. De toren is de middelste toren van de beroemde Gentse torenrij, samen met de Sint-Niklaaskerk en de Sint-Baafskathedraal. Tegen het belfort staat ook de Gentse lakenhal. Geschiedenis Men begon waarschijnlijk te bouwen aan het belfort voor 1314, het jaar waaruit de eerste rekeningen dateren. Een plan in het Bijlokemuseum is van Jan van Haelst, meestermetser. In 1323 waren reeds vier bouwlagen (van de zes geplande) klaar. Tussen 1377 en 1380 werd een voorlopige houten torenbekroning opgetrokken. Daarop werd de legendarische 'Draak van Gent' gehesen. De volgende eeuwen werd de torenspits herhaaldelijk aangepast.Na verschillende houten spitsen, kreeg het belfort in 1851 een neogotische gietijzeren spits. Een halve eeuw later was de staat van de spits echter te slecht geworden, en met de Wereldtentoonstelling van 1913 in het vooruitzicht werd een wedstrijd uitgeschreven voor een nieuwe spits. Een voorstel van Valentin Vaerwyck, gebaseerd op de middeleeuwse spits, werd goedgekeurd. Doordat de werken snel moesten gebeuren, bleken er achteraf vele gebreken te zijn, onder meer in de verbinding tussen de stenen romp en het nieuwe stenen klokkenhuis. In 1967 en 1980 werden daarom restauratiewerken uitgevoerd.";
            belfort.Contact = "Swag";

            ISpot glazenStraatje = new Spot();
            glazenStraatje.Naam = "Glazen straatje";
            glazenStraatje.ImgLink = "http://www.infotalia.com/pictures/steden/250/vanderdonckt1-2.jpg";
            glazenStraatje.Description = "In 1830 waren er verspreid over Gent dertien geautoriseerde rendez-vous-huizen (bordelen). Hier werden de kamers per dag of per uur verhuurd. Een groot deel van de prostituees verkoos om in een stad te werken waarvan ze niet afkomstig waren. Velen kwamen van het platteland en kozen Gent als nieuwe woonplaats.";
            glazenStraatje.Contact = "Swag2";

            spots.Add(belfort);
            spots.Add(glazenStraatje);

            lblVisits.ItemsSource = spots;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {            
            lbResults.ItemsSource = spots;
           
        }

        private void GoVisits(object sender, TappedRoutedEventArgs e)
        {
            pivotMain.SelectedIndex = 1;
        }

        private void GO_Search(object sender, TappedRoutedEventArgs e)
        {
            pivotMain.SelectedIndex = 2;
            
        }

        private void Go_Detail(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = (ListBox)sender;
            ISpot geselecteerd = (ISpot)box.SelectedItem;
            Frame.Navigate(typeof(Detail),geselecteerd);
        
        }

       
    }
}
