using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crawl_Data_Chiasenhac
{
    class chiasenhac
    {
        public string BXH_VN = "https://chiasenhac.vn/nhac-hot/vietnam.html";
        public string BXH_US = "https://chiasenhac.vn/nhac-hot/us-uk.html";
        public string BXH_KO = "https://chiasenhac.vn/nhac-hot/korea.html";

        private List<string> _bxh;

        public List<string> Bxh { get => _bxh; set => _bxh = value; }

        public List<Song> GetBXH(string url)
        {
            var link = CreateHtml(url);

            List<Song> listSong = new List<Song>();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(link);

            var nodeBody = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='music_recommendation']//div[@class='d-table']");
            HtmlNodeCollection nodeListBXH = nodeBody.ChildNodes;

            foreach (var node in nodeListBXH)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    try
                    {
                        Song song = new Song();

                        song.Name = node.ChildNodes[1].InnerText.Replace("\n", " ").Replace("     ", "");
                        song.Author = node.ChildNodes[3].InnerText.Replace("\n", " ").Replace("  ", "");
                        song.Link = node.ChildNodes[5].ChildNodes[1].ChildNodes[1].ChildNodes[0].Attributes["href"].Value;
                        listSong.Add(song);

                        //CardItem item = new CardItem(song.Name, song.Author, song.Link);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            return listSong;
        }

        // Get lyric from song
        public string GetLyric(string url)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(CreateHtml(url));

            string lyrics = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='fulllyric']").InnerText;
            //.Replace("                    ", "");

            return lyrics;
        }

        //Play+Download
        public void DownloadSong(string url)
        {
            var link = CreateHtml(url);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(link);

            var downlink = htmlDoc.DocumentNode.SelectSingleNode("//a[@class='download_item']").Attributes["href"].Value;

            using (WebClient myWebClient = new WebClient())
            {
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(downlink, "1.mp3");
                Console.WriteLine("Download Successfully!!");
            }
        }

        // Create doc Html
        string CreateHtml(string uri)
        {
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();

            return Out;
        }
    }
    public class Song
    {
        private string _name;
        private string _author;
        private string _link;

        //private static Song instance = new Song();
        //private Song() { }

        //private string _lyric;

        public string Name { get => _name; set => _name = value; }
        public string Author { get => _author; set => _author = value; }
        public string Link { get => _link; set => _link = value; }

        // public static Song Instance { get => instance; }
        //public string Lyric { get => _lyric; set => _lyric = value; }
    }
}
