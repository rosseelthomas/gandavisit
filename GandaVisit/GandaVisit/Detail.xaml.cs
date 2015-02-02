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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GandaVisit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detail : Page
    {
        public Detail()
        {
            this.InitializeComponent();
            //instellen van de juiste gegevens
            TxtDiscription.Text = "Het belfort van Gent is een 95-meter hoge belforttoren in het centrum van de Belgische stad Gent. De toren is de middelste toren van de beroemde Gentse torenrij, samen met de Sint-Niklaaskerk en de Sint-Baafskathedraal. Tegen het belfort staat ook de Gentse lakenhal. Geschiedenis Men begon waarschijnlijk te bouwen aan het belfort voor 1314, het jaar waaruit de eerste rekeningen dateren. Een plan in het Bijlokemuseum is van Jan van Haelst, meestermetser. In 1323 waren reeds vier bouwlagen (van de zes geplande) klaar. Tussen 1377 en 1380 werd een voorlopige houten torenbekroning opgetrokken. Daarop werd de legendarische 'Draak van Gent' gehesen. De volgende eeuwen werd de torenspits herhaaldelijk aangepast.Na verschillende houten spitsen, kreeg het belfort in 1851 een neogotische gietijzeren spits. Een halve eeuw later was de staat van de spits echter te slecht geworden, en met de Wereldtentoonstelling van 1913 in het vooruitzicht werd een wedstrijd uitgeschreven voor een nieuwe spits. Een voorstel van Valentin Vaerwyck, gebaseerd op de middeleeuwse spits, werd goedgekeurd. Doordat de werken snel moesten gebeuren, bleken er achteraf vele gebreken te zijn, onder meer in de verbinding tussen de stenen romp en het nieuwe stenen klokkenhuis. In 1967 en 1980 werden daarom restauratiewerken uitgevoerd.";
            DetailsPivot.Title = "Belfort";
            ImgDetail.Source = new BitmapImage(new Uri("http://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/BelfortGent.jpg/210px-BelfortGent.jpg"));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
