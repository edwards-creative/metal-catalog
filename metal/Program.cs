using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace metal
{
    class Program
    {
        public static HtmlWeb web = new HtmlWeb();

        public static void Main(string[] args)
        {
            RunSearch();
        }

        public static void RunSearch()
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

                    Console.WriteLine("Would you like to see their discography? (Y/N)");
                    string getAlbumList = Console.ReadLine();

                    if (getAlbumList.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Discography.GetDiscography();
                        Discography.DisplayDiscography();
                    }
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("\nYou may have entered an incorrect name, try again? (Y/N)");
                    string tryAgain = Console.ReadLine();

                    if (tryAgain.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                finally
                {
                    Console.WriteLine("- * -\n");
                }
            }
        }
    }
}
