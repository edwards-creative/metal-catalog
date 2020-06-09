using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace metal
{
    public static class Band
    {
        public static string name;
        public static string genre;
        public static string location;
        public static string theme;
        public static string bandNumber;
        public static string id;
        public static string baseUrl;
        public static string searchQuery;

        public static string EnterBandName()
        {
            Console.WriteLine($"What band would you like more information on? (\"q\" to quit)");
            name = Console.ReadLine();

            return name;
            
        }

        public static void GetBandInfo()
        { 
            baseUrl = "https://www.metal-archives.com";
            searchQuery = $"{baseUrl}/bands/{name.Replace(" ", "_")}";

            HtmlDocument bandLoadPage = Program.web.Load($"{searchQuery}");

            name = bandLoadPage.DocumentNode.SelectSingleNode("//*[@id='band_info']/h1").InnerText;
            genre = bandLoadPage.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[2]/dd[1]").InnerText;
            location = bandLoadPage.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[1]/dd[2]").InnerText;
            theme = bandLoadPage.DocumentNode.SelectSingleNode("//*[@id='band_stats']/dl[2]/dd[2]").InnerText;

            // Required to get discography:
            bandNumber = bandLoadPage.DocumentNode.SelectSingleNode("//*[@id='band_info']/h1").InnerHtml;
            id = Regex.Match(bandNumber, @"\d+").Value;
        }

        public static void DisplayBandInfo()
        {
            Console.WriteLine("\n- * -\n{0} is based out of {1}", name, location);
            Console.WriteLine("They produce {0}, with lyrical themes of {1}\n", genre, theme);
            // Console.WriteLine("The band id is {0}", id);
        }

    }
}
