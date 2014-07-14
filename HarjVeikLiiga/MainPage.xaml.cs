using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HarjVeikLiiga.Resources;
using HarjVeikLiiga.Controls;
using AdvancedREI.Net.Http.Compression;
using System.Net.Http;
using Newtonsoft.Json;

namespace HarjVeikLiiga
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string JSONMatchInfo;
        private List<Match> matches;
        private List<DateTime> dates;

        public MainPage()
        {
            InitializeComponent();
            Uri uri = new Uri("http://adafyvlstorage.blob.core.windows.net/2014/finland/veikkausliiga/matches");
            MainMatchInfo(uri);
        }

        private async void MainMatchInfo(Uri uri)
        { 
            var handler = new CompressedHttpClientHandler();
            var client = new HttpClient(handler);
            // Virheenkäsittely?
            JSONMatchInfo = await client.GetStringAsync(uri);
            deserializeMatchInfo();
            viewMatchInfo();
        }

        private void deserializeMatchInfo()
        {
            matches = JsonConvert.DeserializeObject<List<Match>>(JSONMatchInfo);
        }

        private void viewMatchInfo()
        {
            dates = new List<DateTime>();

            // Add matches starting from today.
            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                if (match.MatchDate.Date >= DateTime.Today.Date)
                {
                    // Luodaan päivämääränäkymä
                    if (dates.Count == 0 || dates[dates.Count - 1] != match.MatchDate)
                    {
                        DateView dateView = createDateView(match.MatchDate);
                        dates.Add(match.MatchDate);
                    } 
                    createMatchView(match);
                }
            }
        }

        private DateView createDateView(DateTime date)
        {
            DateView dateView = new DateView(date);
            DateStack.Children.Add(dateView);
            return dateView;
        }

        private void createMatchView(Team HomeTeam, Team AwayTeam, string Result)
        {
            MatchView matchView;
            matchView = new MatchView(HomeTeam.GetName(), AwayTeam.GetName(), Result);
            DateStack.Children.Add(matchView);
        }

        private void createMatchView(Match match)
        {
            MatchView matchView;
            matchView = new MatchView(match);
            DateStack.Children.Add(matchView);
        }
    }
}