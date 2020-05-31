using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace metal
{
    public static class Album
    {
        public static HtmlNode table;
        public static HtmlNode td;

        public static string title;
        public static int selectAlbumIndex;

        public static void AlbumList()
        {
            foreach (var album in Discography.albumList)
            {
                Console.WriteLine("{0}. {1}",selectAlbumIndex, album);
                selectAlbumIndex++;
            }
        }

       public static void GetAlbum()
        {
            Console.WriteLine($"What album would you like to view? (1-{selectAlbumIndex}");
            var userAlbumSelection = Console.ReadLine();
            HtmlDocument albumLoadPage = Program.web.Load($"{Discography.albumList[Convert.ToInt32(userAlbumSelection)]}");
            for (int i = 0; i < Discography.albumList.Count; i++)
            {
                title = albumLoadPage.DocumentNode.SelectSingleNode($"//*[@id='album_tabs_tracklist']/div[2]/table/tbody/tr[1]/td[2]").InnerText;
                Console.WriteLine(title);

            }
        }
        
    }
}
