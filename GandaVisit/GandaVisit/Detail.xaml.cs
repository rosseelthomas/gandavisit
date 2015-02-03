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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GandaVisit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Detail : Page
    {
        ISpot current_spot;
        public Detail()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += OnBackPressed;
            
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
            TxtDiscription.Text=s.Description;
            DetailsPivot.Title =s.Naam;
            ImgDetail.Source = new BitmapImage(new Uri(s.ImgLink));
            
            //instellen Contact
            Set_Contact(s);
           

        }

        private void Set_Contact(ISpot s)
        {
            //address
            if (s.Contact.City == null && s.Contact.AdressNumber == 0 && s.Contact.Street == null)
            {
                gAdres.Visibility = Visibility.Collapsed;
            }
            else
            {
                gAdres.Visibility = Visibility.Visible;
                if (s.Contact.City != null)
                {
                    txtCity.Visibility = Visibility.Visible;
                    txtCity.Text = s.Contact.City;
                }
                else
                {
                    txtCity.Visibility = Visibility.Collapsed;
                }

                if (s.Contact.Street != null)
                {

                    txtStreet.Visibility = Visibility.Visible;
                    if (s.Contact.AdressNumber != 0)
                    {
                        txtStreet.Text = s.Contact.Street + " " + s.Contact.AdressNumber;
                    }
                    else
                    {
                        txtStreet.Text = s.Contact.Street;
                    }

                }
                else
                {
                    txtStreet.Visibility = Visibility.Collapsed;
                }

            }

            if (s.Contact.Fax != 0)
            {
                gFax.Visibility = Visibility.Visible;
                txtFax.Text = s.Contact.Fax.ToString();
            }
            else
            {
                gFax.Visibility = Visibility.Collapsed;
            }

            if (s.Contact.PhoneNumber != 0)
            {
                gPhone.Visibility = Visibility.Visible;
                txtPhone.Text = s.Contact.PhoneNumber.ToString();
            }
            else
            {
                gPhone.Visibility = Visibility.Collapsed;
            }

            if (s.Contact.Website != null)
            {
                gWebsite.Visibility = Visibility.Visible;
                txtWebsite.Text = s.Contact.Website;
            }
            else
            {
                gWebsite.Visibility = Visibility.Collapsed;
            }

            if (s.Contact.Email != null)
            {
                gEmail.Visibility = Visibility.Visible;
                txtEmail.Text = s.Contact.Email;
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

       
    }
}
