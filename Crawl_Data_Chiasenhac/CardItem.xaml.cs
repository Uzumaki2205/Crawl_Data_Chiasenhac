using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CardItem.xaml
    /// </summary>
    public partial class CardItem : UserControl
    {
        public CardItem()
        {
            InitializeComponent();
        }
    }

    //public class SongInfo
    //{
    //    private string _nameSong;
    //    private string _authorSong;
    //    private string _linkSong;

    //    public string NameSong { get => _nameSong; set => _nameSong = value; }
    //    public string AuthorSong { get => _authorSong; set => _authorSong = value; }
    //    public string LinkSong { get => _linkSong; set => _linkSong = value; }

    //    public SongInfo()
    //    {
    //        _nameSong = "";
    //        _authorSong = "";
    //        _linkSong = "";
    //    }

    //    public SongInfo(string nameSong, string authorSong, string linkSong)
    //    {
    //        _nameSong = nameSong;
    //        _authorSong = authorSong;
    //        _linkSong = linkSong;
    //    }
    //}

    //public class ListSongInfo
    //{
    //    //private static ListSongInfo instance = new ListSongInfo();
    //    //private ListSongInfo() { }

    //    //public static ListSongInfo Instance { get => instance; }

    //    public List<Song> GetSongInfo()
    //    {
    //        chiasenhac csn = new chiasenhac();

    //        Song song = new Song();

    //        var listSong = csn.GetBXH(csn.BXH_VN);

    //        return listSong;
    //    }
    //}
}
