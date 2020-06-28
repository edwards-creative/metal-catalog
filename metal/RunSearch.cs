using System;
namespace metal
{
    public class RunSearch
    {
        public static int albumSelect = 0;


        public static void Search()
        {
            while (true)
            {
                Band.EnterBandName();
                if (Band.name.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                try
                {
                    Band.GetBandInfo();
                    Band.DisplayBandInfo();

                    Discography.GetDiscography();
                    Discography.DisplayDiscography();

                    SpreadsheetConnector spreadsheet = new SpreadsheetConnector();
                    Console.WriteLine("\nSelect an Album 1-{0}", Discography.albumCount);
                    spreadsheet.CreateEntry();
                }
                catch (System.NullReferenceException)
                {
                    // string bandlist = $"{Band.baseUrl}/search?searchString={Band.name}&type=band_name";
                    // HtmlAgilityPack.HtmlDocument bandListDocument = Program.web.Load($"{bandlist}");

                    // string bandNames = bandListDocument.DocumentNode.SelectSingleNode("//*[@id='searchResults_info']").InnerText;
                    Console.WriteLine("\nYou may have entered an incorrect name, or duplicates exist. Please try again.");
                    // Console.WriteLine(bandNames);
                }

                finally
                {
                    Console.WriteLine("- * -\n");
                }
            }
        }
    }
}
