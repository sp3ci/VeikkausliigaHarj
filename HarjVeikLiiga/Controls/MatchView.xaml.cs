using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;

namespace HarjVeikLiiga.Controls
{
    public partial class MatchView : UserControl
    {
        private Match match;
        private string JSONMatch;

        public MatchView(string joukkue1, string joukkue2, string tulos)
        {
            InitializeComponent();
            this.joukkue1.Text = joukkue1;
            this.joukkue2.Text = joukkue2;
            this.tulos.Text = tulos;
        }

        public MatchView(Match match)
        {
            InitializeComponent();
            this.joukkue1.Text = match.HomeTeam.GetName();
            this.joukkue2.Text = match.AwayTeam.GetName();
            this.tulos.Text = match.HomeGoals + " - " + match.AwayGoals;
            this.match = match;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            JSONMatch = JsonConvert.SerializeObject(match);
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/MatchInfoPage.xaml?msg=" + JSONMatch, UriKind.Relative));
        }
    }
}
