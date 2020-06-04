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

                    Console.WriteLine("Would you like to see their discography? (Y/N)");
                    string getDiscography = Console.ReadLine();

                    if (getDiscography.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Discography.GetDiscography();
                        Discography.DisplayDiscography();

                        // Album.AlbumList();
                        // Album.GetAlbum();
                        // Album.DisplayTrackList();

                        continue;
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
                    // Console.WriteLine(Band.baseUrl, Discography.discographyUrl);
                    // Console.WriteLine(Discography.albumUrl);
                    Console.WriteLine("- * -\n");
                }
            }
        }
    }
}
