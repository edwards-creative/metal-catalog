using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace metal
{
    public static class Discography
    {
        public static HtmlNode table;
        public static HtmlNode td;

        public static string title;
        public static string year;
        public static string type;
        public static string discographyUrl;
        public static string albumUrl;
        public static List<string> albumList;
        public static string extractAlbumUrl;
        public static int count = 1;
        public static int albumCount;

        public static void GetDiscography()
        {
            discographyUrl = $"{Band.baseUrl}/band/discography/id/{Band.id}/tab/all";
            HtmlDocument discographyLoadPage = Program.web.Load($"{discographyUrl}");
            table = discographyLoadPage.DocumentNode.SelectSingleNode("//table[contains(@class, 'discog')]");
            td = table.SelectSingleNode("//tr/td");
        }

        // Loop through the table and write the album names until there are no more albums to list:
        public static void DisplayDiscography()
        {
            albumList = new List<string>();
            try
            {
                while (td != null)
                {
                    title = table.SelectSingleNode($"//tr[{count}]/td[1]").InnerText;
                    year = table.SelectSingleNode($"//tr[{count}]/td[3]").InnerText;
                    type = table.SelectSingleNode($"//tr[{count}]/td[2]").InnerText;
                    albumUrl = $"{Band.baseUrl}/albums/{Band.name.Replace(" ", "_")}/{title.Replace(" ", "_")}/";
                    albumList.Add(albumUrl);

                    Console.WriteLine("{0}. {1} ({2}, {3})", count, title, type, year);
                    count++;
                }
            }

            catch (System.NullReferenceException)
            {
                albumCount = albumList.Count;
                Console.WriteLine("\nNo more albums to list, {0} albums total.", albumCount);
            }
            /* foreach (var album in albumList)
            {
                Console.WriteLine(album);
            }*/
            
        }
    }
}

