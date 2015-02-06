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

        ISpotDAO dao;
        bool first_load = true;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            dao = (ISpotDAO)App.Current.Resources["dao"];

            this.Loaded += MainPage_Loaded;


        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (first_load)
            {
                prVisits.Visibility = Visibility.Visible;
                prVisits.IsActive = true;
                await dao.LoadVisits();
                prVisits.IsActive = false;
                prVisits.Visibility = Visibility.Collapsed;
                lblVisits.ItemsSource = null;
                lblVisits.ItemsSource = dao.Visits;
                first_load = false;
            }

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

            //updaten visits menu
            //lblVisits.SelectedIndex = -1;

            //Om crash te vermijden
            lblVisits.ItemsSource = null;
            lblVisits.ItemsSource = dao.Visits;


            lbResults.SelectedIndex = -1;

        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            txtNotFound.Visibility = Visibility.Collapsed;
            lbResults.Visibility = Visibility.Collapsed;
            prSearch.Visibility = Visibility.Visible;
            prSearch.IsActive = true;
            List<ISpot> lijst = await dao.SearchName(txtSearch.Text);
            prSearch.IsActive = false;
            prSearch.Visibility = Visibility.Collapsed;
            lbResults.ItemsSource = lijst;

            if (lijst.Count == 0)
            {
                txtNotFound.Visibility = Visibility.Visible;
                lbResults.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtNotFound.Visibility = Visibility.Collapsed;
                lbResults.Visibility = Visibility.Visible;
            }

        }

        private void GoVisits(object sender, TappedRoutedEventArgs e)
        {
            pivotMain.SelectedIndex = 1;
        }

        private void GO_Search(object sender, TappedRoutedEventArgs e)
        {
            pivotMain.SelectedIndex = 2;

        }

        private async void Go_Detail(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = (ListBox)sender;
            if (box.SelectedIndex != -1)
            {
                ISpot geselecteerd = (ISpot)box.SelectedItem;

                //ophalen details
                btnSearch.Visibility = Visibility.Collapsed;
                prDetails.Visibility = Visibility.Visible;
                prDetails.IsActive = true;
                await dao.AddDetails(geselecteerd);
                prDetails.IsActive = false;
                prDetails.Visibility = Visibility.Collapsed;
                btnSearch.Visibility = Visibility.Visible;
                Frame.Navigate(typeof(Detail), geselecteerd);
            }


        }

        private void GO_About(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void btnClearVisits_Click(object sender, RoutedEventArgs e)
        {
            lblVisits.ItemsSource = null;
            dao.ClearVisits();
            lblVisits.ItemsSource = dao.Visits;
        }


    }
}
