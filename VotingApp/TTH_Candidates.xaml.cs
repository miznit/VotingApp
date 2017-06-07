using SQLite.Net;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VotingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TTH_Candidates : Page
    {
        public TTH_Candidates()
        {
            this.InitializeComponent();
        }

        private void btnTTHNext_Click(object sender, RoutedEventArgs e)
        {
            

            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            var conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //conn.CreateTable<User>();

            if (((RadioButton)radioButtonTTH1).IsChecked ?? true)
            {
                currentUser.candidateVote = radioButtonTTH1.Content.ToString();

                //MainPage.theUser.CandidateVote = radioButtonTTH1.Content.ToString();

                //conn.InsertOrReplace(MainPage.theUser);

            }

            else if (((RadioButton)radioButtonTTH2).IsChecked ?? true)
            {
                currentUser.candidateVote = radioButtonTTH2.Content.ToString();
                //MainPage.theUser.CandidateVote = radioButtonTTH2.Content.ToString();
                //conn.InsertOrReplace(MainPage.theUser);

            }

            else if (((RadioButton)radioButtonTTH3).IsChecked ?? true)
            {
                currentUser.candidateVote = radioButtonTTH3.Content.ToString();
                //MainPage.theUser.CandidateVote = radioButtonTTH3.Content.ToString();
                //conn.InsertOrReplace(MainPage.theUser);

            }

            this.Frame.Navigate(typeof(PartyVote));
        }
    }
}
