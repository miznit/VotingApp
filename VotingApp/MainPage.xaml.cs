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
using VotingApp.Models;
using SQLite.Net;
using SQLite.Net.Attributes;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VotingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<User> users;
        static public User theUser;
        private string path;

        SQLiteConnection conn;

        public string lastNameText;

           




        public MainPage()
        {
            this.InitializeComponent();
            theUser = new User();
            users = UserManager.GetUsers();
                      
            //this creates the path, connection, and table in the SQLite database            
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<User>();


        }
        #region
        //button click event for the submit button on the main page
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
                foreach (var user in users)
                {
                    if (textboxLastName.Text == user.LastName && textboxFirstNames.Text == user.FirstNames && textboxElectoralID.Text == user.ElectoralID)
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

                
               
            }

            if (textboxLastName.Text != "O'Reilly" || textboxLastName.Text!= "Baker" || textboxLastName.Text != "Dover")
            {
                var Dialog1 = new MessageDialog("You have entered an incorrect Last Name","CHECK LAST NAME");
                await Dialog1.ShowAsync();
            }

            if (textboxFirstNames.Text != "Paddy Dougal" || textboxFirstNames.Text != "Norma-Jean" || textboxFirstNames.Text != "Ben James")
            {
                var Dialog2 = new MessageDialog("You have entered incorrect First Names", "CHECK FIRST NAMES");
                await Dialog2.ShowAsync();
            }

            if (textboxElectoralID.Text!= "PMR123456" || textboxElectoralID.Text!= "TTH123456" || textboxElectoralID.Text!="RAN123456")
            {
                var Dialog3 = new MessageDialog("You have entered an incorrect Electoral ID", "CHECK ELECTORAL ID");
                await Dialog3.ShowAsync();
            }






            currentUser.lastName = textboxLastName.Text;
            currentUser.firstNames = textboxFirstNames.Text;
            currentUser.dateOfBirth = DatePicker.Date.ToString("yyyy-MM-dd");
            currentUser.electoralID = textboxElectoralID.Text;
            currentUser.timeOfVote = DateTime.Now.ToString();



          
        }
        #endregion

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
