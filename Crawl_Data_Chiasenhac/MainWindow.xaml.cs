using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crawl_Data_Chiasenhac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        chiasenhac csn = new chiasenhac();
        public MainWindow()
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.DataContext = this;
        }
        
        private void btnBXHVN_Click(object sender, RoutedEventArgs e)
        {
            stackContent.Children.Clear();
            GetListSong(csn.BXH_VN);
        }

        void GetListSong(string url)
        {
            var listSong = csn.GetBXH(url);
     
            foreach (var item in listSong)
            {
                CardItem card = new CardItem();
                card.nameSong.Text = item.Name;
                card.authorSong.Text = item.Author;
                card.linkSong.Content = item.Link;

                stackContent.Children.Add(card);
            }
        }

        private void btnBXHUS_Click(object sender, RoutedEventArgs e)
        {
            stackContent.Children.Clear();
            GetListSong(csn.BXH_US);
        }

        private void btnBXHKO_Click(object sender, RoutedEventArgs e)
        {
            stackContent.Children.Clear();
            GetListSong(csn.BXH_KO);
        }
    }
}
