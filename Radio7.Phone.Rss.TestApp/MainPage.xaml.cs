using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Radio7.Portable.Rss;

namespace Radio7.Phone.Rss.TestApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var url = Url.Text;

            var feed = new Feed(new Uri(url, UriKind.Absolute));

            feed.FeedLoaded += (o, args) =>
            {
                var firstOrDefault = feed.Items.FirstOrDefault();
                WithDispatcher(() =>
                {
                    if (firstOrDefault != null) Results.Text = firstOrDefault.Title;
                });
            };

            feed.GetItemsFromWeb();
        }

        private static void WithDispatcher(Action action)
        {
            Deployment.Current.Dispatcher.BeginInvoke(action);
        }
    }
}