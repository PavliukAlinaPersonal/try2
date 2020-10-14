using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PracticeTestFramework.Helpers
{
    
    class APIGoogleTables
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Legislators";
        static readonly string SpreadsheetId = "1wlybu4laTmK88Ee7XVf31jlYgksuMT3naQgi8vpevnI";
        static readonly string sheet = "rr";

        static SheetsService service;

        public static void APIGoogleTablesCreate() {
            GoogleCredential credential;
            using (var stream = new FileStream(@"resources\mfp.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            ReadEntries();
        }

        static void ReadEntries()
        {
            var range = $"{sheet}!A:B";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId,range);

            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            
        }
    }
}
