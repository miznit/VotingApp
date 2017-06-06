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
using System.Text.RegularExpressions;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VotingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnMainPageSubmit_Click(object sender, RoutedEventArgs e)
        {
            lastNameRegex(@"^([a-zA-Z\s\'\-]+)$", textboxLastName);
            firstNameRegex(@"^([a-zA-Z\s\'\-]+)$", textboxFirstNames);
            electoralIDRegex(@"^([A-Z]{3})([0-9]{6})$", textboxElectoralID);

            if (textboxLastName.Text == "" || textboxFirstNames.Text == "" || textboxElectoralID.Text == "")
            {
                var Dialog = new MessageDialog("Please make sure you have completed all fields");
                await Dialog.ShowAsync();
            }
            else

            {
                if (textboxElectoralID.Text.Contains("PMR"))
                {
                   this.Frame.Navigate(typeof(PMR_Candidates));
                }

                else if (textboxElectoralID.Text.Contains("TTH"))
                {
                   this.Frame.Navigate(typeof(TTH_Candidates));
                }

                else if (textboxElectoralID.Text.Contains("RAN"))
                {
                    this.Frame.Navigate(typeof(RAN_Candidates));
                }
            }
        }

        public void lastNameRegex(string re, TextBox tb)
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(tb.Text))
            {
                textboxLastName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else if (!regex.IsMatch(tb.Text))
            {
                textboxLastName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }


        }

        public void firstNameRegex(string re, TextBox tb)
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(tb.Text))
            {
                textboxFirstNames.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else if (!regex.IsMatch(tb.Text))
            {
                textboxFirstNames.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        public void electoralIDRegex(string re, TextBox tb)
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(tb.Text))
            {
                textboxElectoralID.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else if (!regex.IsMatch(tb.Text))
            {
                textboxElectoralID.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void textboxLastName_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            lastNameRegex(@"^([a-zA-Z\s\'\-]+)$", textboxLastName);
        }

        private void textboxElectoralID_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            electoralIDRegex(@"^([A-Z]{3})([0-9]{6})$", textboxElectoralID);
        }

        private void textboxFirstNames_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            firstNameRegex(@"^([a-zA-Z\s\'\-]+)$", textboxFirstNames);
        }
    }
}
