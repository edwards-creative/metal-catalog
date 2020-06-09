using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace metal
{
    public class SpreadsheetConnector
    {
        public static readonly String[] Scopes = { SheetsService.Scope.Spreadsheets };
        public static readonly string ApplicationName = "Catalog";
        public static readonly string SpreadsheetId = "1P_uzYbO3rI6GsR0fUo9BkKsRlQHcfd5mm191i_rZgV8";
        public static readonly string Sheet = "catalog";
        public static SheetsService service;

        public SpreadsheetConnector()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.ReadWrite))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        public void ReadEntries()
        {
            var range = $"{Sheet}!A2:F10";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();

            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    Console.WriteLine("{0}: {1} ({2})", row[0], row[2], row[3]);
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        public void CreateEntry()
        {
            var range = $"{Sheet}!A:F";
            var valueRange = new ValueRange();

            var objectList = new List<object>()
            {
                $"{Band.name}",
                $"{Discography.title}",
                $"{Band.genre}",
                $"{Band.location}",
                $"{Band.theme}"
            };
            valueRange.Values = new List<IList<object>> { objectList };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResposne = appendRequest.Execute();
        }
    }
}
