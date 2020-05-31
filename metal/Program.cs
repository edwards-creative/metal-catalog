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
            RunSearch.Search();

        }
    }
}
