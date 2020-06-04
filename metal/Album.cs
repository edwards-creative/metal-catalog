using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace metal
{
    public class Album : Discography
    {
        public static HtmlDocument albumLoadPage;
        public static string userAlbumSelection;
        public static int selectAlbumIndex = 0;

        public static void AlbumList()
        {
            foreach (var album in Discography.albumList)
            {
                Console.WriteLine("{0}. {1}", selectAlbumIndex, album);
                selectAlbumIndex += 1;
            }
        }

        public static void GetAlbum()
        {
            Console.WriteLine($"\nSelect an album (0-{albumCount}, or continue searching. Y/N)");
            userAlbumSelection = Console.ReadLine();

            albumLoadPage = Program.web.Load($"{Discography.albumList[Convert.ToInt32(userAlbumSelection)]}");
            table = albumLoadPage.DocumentNode.SelectSingleNode("//table[contains(@class, 'display table_lyrics')]");
            td = table.SelectSingleNode("//td[contains(@class,'wrapWords')]");

        }
        public static void DisplayTrackList()
        {
            while (td != null)
            {
                string trackName = table.SelectSingleNode($"//*[@id='album_tabs_tracklist']/div[2]/table/tbody/tr[{count}]/td[2]").InnerText;
                Console.WriteLine(trackName);
                count += 2;
            }

        }

    }
}
