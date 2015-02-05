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
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            dao = (ISpotDAO)App.Current.Resources["dao"];

            lblVisits.ItemsSource = dao.Visits;
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
            lblVisits.ItemsSource = dao.Visits;

            //search leegmaken
            lbResults.SelectedIndex = -1;

        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lbResults.ItemsSource = await dao.SearchName(txtSearch.Text);


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
                await dao.AddDetails(geselecteerd);
                Frame.Navigate(typeof(Detail), geselecteerd);
            }


        }

        private void GO_About(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }


    }
}
