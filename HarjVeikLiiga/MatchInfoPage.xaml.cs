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
using System.Windows.Media.Imaging;

namespace HarjVeikLiiga
{
    public partial class MatchInfoPage : PhoneApplicationPage
    {
        public MatchInfoPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string msg = "";
            if (NavigationContext.QueryString.TryGetValue("msg", out msg))
            {
                Match match = JsonConvert.DeserializeObject<Match>(msg);
                HomeTeam.Text = match.HomeTeam.GetName();
                AwayTeam.Text = match.AwayTeam.GetName();
                Result.Text = match.HomeGoals + " - " + match.AwayGoals;

                HomeTeamLogo.Source = setupImage(match.HomeTeam.LogoUrl);
                AwayTeamLogo.Source = setupImage(match.AwayTeam.LogoUrl);
            }
        }

        private BitmapImage setupImage(string sourceURI)
        {
            BitmapImage hLogo = new BitmapImage();
            hLogo.DecodePixelWidth = 117;
            hLogo.UriSource = new Uri(sourceURI);
            return hLogo;
        }
    }
}