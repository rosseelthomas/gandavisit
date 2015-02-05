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
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.Services.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GandaVisit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detail : Page
    {
        ISpot current_spot;
        ISpotDAO dao;
        public Detail()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;

            dao = (ISpotDAO)App.Current.Resources["dao"];

        }

        private void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            ISpot s = (ISpot)e.Parameter;

            current_spot = s;
            //instellen van de juiste gegevens
            TxtDiscription.Text = s.Description;
            DetailsPivot.Title = s.Naam;
            ImgDetail.Source = new BitmapImage(new Uri(s.ImgLink));

            //instellen Contact
            Set_Contact();

            Set_AddVisits();

            Geopoint p = new Geopoint(new BasicGeoposition()
            {
                Latitude = current_spot.Latitude,
                Longitude = current_spot.Longitude
            });

            Set_Map(p, current_spot.Naam);
        }

        private void Set_Contact()
        {
            //address
            if (current_spot.Contact.City == null && current_spot.Contact.AdressNumber == 0 && current_spot.Contact.Street == null)
            {
                gAdres.Visibility = Visibility.Collapsed;
            }
            else
            {
                gAdres.Visibility = Visibility.Visible;
                if (current_spot.Contact.City != null)
                {
                    txtCity.Visibility = Visibility.Visible;
                    txtCity.Text = current_spot.Contact.City;
                }
                else
                {
                    txtCity.Visibility = Visibility.Collapsed;
                }

                if (current_spot.Contact.Street != null)
                {

                    txtStreet.Visibility = Visibility.Visible;
                    if (current_spot.Contact.AdressNumber != 0)
                    {
                        txtStreet.Text = current_spot.Contact.Street + " " + current_spot.Contact.AdressNumber;
                    }
                    else
                    {
                        txtStreet.Text = current_spot.Contact.Street;
                    }

                }
                else
                {
                    txtStreet.Visibility = Visibility.Collapsed;
                }

            }

            if (current_spot.Contact.Fax != 0)
            {
                gFax.Visibility = Visibility.Visible;
                txtFax.Text = current_spot.Contact.Fax.ToString();
            }
            else
            {
                gFax.Visibility = Visibility.Collapsed;
            }

            if (current_spot.Contact.PhoneNumber != 0)
            {
                gPhone.Visibility = Visibility.Visible;
                txtPhone.Text = current_spot.Contact.PhoneNumber.ToString();
            }
            else
            {
                gPhone.Visibility = Visibility.Collapsed;
            }

            if (current_spot.Contact.Website != null)
            {
                gWebsite.Visibility = Visibility.Visible;
                txtWebsite.Text = current_spot.Contact.Website;
            }
            else
            {
                gWebsite.Visibility = Visibility.Collapsed;
            }

            if (current_spot.Contact.Email != null)
            {
                gEmail.Visibility = Visibility.Visible;
                txtEmail.Text = current_spot.Contact.Email;
            }
            else
            {
                gEmail.Visibility = Visibility.Collapsed;
            }
        }

        private void Phone_Pressed(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(current_spot.Contact.PhoneNumber.ToString(), current_spot.Naam);

        }

        private async void Email_Pressed(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.Email.EmailMessage mail = new Windows.ApplicationModel.Email.EmailMessage();
            mail.To.Add(new Windows.ApplicationModel.Email.EmailRecipient(current_spot.Contact.Email, current_spot.Naam));
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(mail);
        }

        private async void Website_pressed(object sender, TappedRoutedEventArgs e)
        {
            string uriToLaunch = @current_spot.Contact.Website;
            var uri = new Uri(uriToLaunch);
            // Set the option to show a warning
            var options = new Windows.System.LauncherOptions();
            options.TreatAsUntrusted = true;

            // Launch the URI with a warning prompt
            var success = await Windows.System.Launcher.LaunchUriAsync(uri, options);
        }

        private void BtnAddVisit_Click(object sender, RoutedEventArgs e)
        {
            if (current_spot.IsVisists)
            {
                dao.RemoveVisits(current_spot);
            }
            else
            {
                dao.AddVisits(current_spot);
            }

            Set_AddVisits();
        }

        private void Set_AddVisits()
        {
            //instellen van de AddVisistsButton
            if (current_spot.IsVisists)
            {
                BtnAddVisit.Content = "Remove from visits";
            }
            else
            {
                BtnAddVisit.Content = "Add to visists";
            }
        }

        private void Go_Location(object sender, TappedRoutedEventArgs e)
        {
            DetailsPivot.SelectedIndex = 3;
        }

        private void Set_Map(Geopoint p, string text)
        {
            try
            {
                MapControlLocation.Center = p;
                MapControlLocation.ZoomLevel = 17;
                MapControlLocation.LandmarksVisible = true;

                //tonen van icoon
                MapIcon mapIcon = new MapIcon();
                mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPijl.png"));
                mapIcon.NormalizedAnchorPoint = new Point(0.5, 1);
                mapIcon.Title = text;
                mapIcon.Location = p;

                MapControlLocation.MapElements.Add(mapIcon);
            }
            catch (Exception ex)
            {
                ErrorMap();
            }



        }

        private async void CalculateRoute()
        {

            Geolocator locator = new Geolocator();
            Geoposition geopos = null;



            try
            {
                geopos = await locator.GetGeopositionAsync();
                Set_Map(geopos.Coordinate.Point, "Start");
                Geopoint eind = new Geopoint(new BasicGeoposition()
                {
                    Latitude = current_spot.Latitude,
                    Longitude = current_spot.Longitude
                });
                MapRouteFinderResult result = await MapRouteFinder.GetWalkingRouteAsync(geopos.Coordinate.Point, eind);
                if (result.Status == MapRouteFinderStatus.Success)
                {
                    MapRouteView view = new MapRouteView(result.Route);
                    view.RouteColor = Colors.Blue;
                    view.OutlineColor = Colors.Red;
                    MapControlLocation.Routes.Add(view);
                    await MapControlLocation.TrySetViewBoundsAsync(result.Route.BoundingBox, null, Windows.UI.Xaml.Controls.Maps.MapAnimationKind.Bow);
                }
            }
            catch (Exception ex)
            {
                ErrorMap();
            }

        }

        private async void ErrorMap()
        {
            //message tonen
            MessageDialog d = new MessageDialog("An error occured: Is location/internet on?");
            d.Commands.Add(new UICommand("Try again", new UICommandInvokedHandler(this.MessageTryAgain)));
            d.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(this.MessageCancel)));
            await d.ShowAsync();
        }

        private void MessageTryAgain(IUICommand command)
        {
            CalculateRoute();
        }

        private void MessageCancel(IUICommand command)
        {
            //do nothing
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DetailsPivot.SelectedIndex = 3;
            MapControlLocation.MapElements.Clear();
            MapControlLocation.Routes.Clear();

            //naar huidig spot gaan
            Geopoint p = new Geopoint(new BasicGeoposition()
            {
                Latitude = current_spot.Latitude,
                Longitude = current_spot.Longitude
            });

            Set_Map(p, current_spot.Naam);
        }

        private void btnRoute_Click(object sender, RoutedEventArgs e)
        {
            DetailsPivot.SelectedIndex = 3;
            CalculateRoute();
        }




    }
}
