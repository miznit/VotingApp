using SQLite.Net;
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
    public sealed partial class Summary : Page
    {
        private SQLiteConnection conn;
        private string path;

       
        public Summary()
        {
            this.InitializeComponent();
            
            textBoxSummary1.Text = currentUser.candidateVote;
            textBoxSummary2.Text = currentUser.partyVote;
            textBoxSummary3.Text = currentUser.referendumVote;

            

        }

        private void btnSummaryBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnSummarySubmit_Click(object sender, RoutedEventArgs e)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<User>();

            conn.Insert(new User()
            {
                ElectoralID = currentUser.electoralID,
                LastName = currentUser.lastName,
                FirstNames = currentUser.firstNames,
                DateOfBirth = currentUser.dateOfBirth,
                CandidateVote = currentUser.candidateVote,
                PartyVote = currentUser.partyVote,
                ReferendumVote = currentUser.referendumVote,
                TimeOfVote = currentUser.timeOfVote
            });

        }
    }
}
