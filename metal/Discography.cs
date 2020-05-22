using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        public static string extractAlbumUrl;


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
            int count = 1;
            try
            {
                while (td != null)
                {
                    title = table.SelectSingleNode($"//tr[{count}]/td[1]").InnerText;
                    year = table.SelectSingleNode($"//tr[{count}]/td[3]").InnerText;
                    type = table.SelectSingleNode($"//tr[{count}]/td[2]").InnerText;

                    albumUrl = $"{Band.baseUrl}/albums/{Band.name.Replace(" ", "_")}/{title.Replace(" ", "_")}/";
                    Console.WriteLine(albumUrl);

                    Console.WriteLine("{0}: {1} ({2})\n", year, title, type);
                    count++;
                }
            }

            catch (System.NullReferenceException)
            {
                int totalAlbums = count - 1;
                Console.WriteLine("\nNo more albums to list, {0} albums total.", totalAlbums);
            }
        }
    }
}

