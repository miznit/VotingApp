using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VotingApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VotingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReferendumVote : Page
    {
        private string path;
        static public User theUser;
        SQLiteConnection conn;

        

        public ReferendumVote()
        {
            this.InitializeComponent();

            theUser = new User();

            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            var conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<User>();
        }

        private void btnRVNext_Click(object sender, RoutedEventArgs e)
        {
            
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            var conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //conn.CreateTable<User>();

            if (((RadioButton)radioButtonRV1).IsChecked == true)
            {
                currentUser.referendumVote = radioButtonRV1.Content.ToString();

                //MainPage.theUser.ReferendumVote = radioButtonRV1.Content.ToString();

                //conn.InsertOrReplace(MainPage.theUser);

            }

            else if (((RadioButton)radioButtonRV2).IsChecked == true)
            {
                currentUser.referendumVote = radioButtonRV2.Content.ToString();
                //MainPage.theUser.ReferendumVote = radioButtonRV2.Content.ToString();
                //conn.InsertOrReplace(MainPage.theUser);

            }

            //theUser.LastName = lastNameText;
            //theUser.FirstNames = textboxFirstNames.Text;
            //theUser.DateOfBirth = DatePicker.Date.ToString("yyyy-MM-dd");
            //theUser.ElectoralID = textboxElectoralID.Text;
            //theUser.TimeOfVote = DateTime.Now.ToString();
            //var s = conn.Insert(theUser);
           // var s = conn.Insert(theUser);
            this.Frame.Navigate(typeof(Summary));

            
        }
    }
}