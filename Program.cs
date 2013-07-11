using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace GeoCodeClient
{
    class Program
    {
        static ConcurrentBag<GeoCodeList> geoCodes = new ConcurrentBag<GeoCodeList>();

        static void Main(string[] args)
        {
            var baseUrl = "http://maps.googleapis.com/maps/api/geocode/json";
            var paramsUrl = "?address={0},{1}&sensor=false";
            FileLoader loader = new FileLoader();
            GeoCodeContext context = new GeoCodeContext();

            var urlParams = loader.GetAtmList().Select(p => string.Format(paramsUrl, p.Street, p.City));

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Parallel.ForEach(urlParams, (pramsUrl, state) =>
            {
                try
                {
                    if (geoCodes.Count > 100)
                        state.Break();

                    GetGeoCode(context, client, pramsUrl);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
                
            });

            foreach (var geoCode in geoCodes)
            {
                context.geoCodeLists.Add(geoCode);
            }

            context.SaveChanges();
        }

        private static void GetGeoCode(GeoCodeContext context, HttpClient client, string pramsUrl)
        {
            client.GetAsync(pramsUrl)
            .ContinueWith(t =>
            {
                HttpResponseMessage response;

                response = t.Result;
                response.EnsureSuccessStatusCode();

                var readTask = response.Content.ReadAsAsync<GeoCodeList>();
                readTask.Wait();

                var status = readTask.Result.Status;

                if (status == "OVER_QUERY_LIMIT")
                {
                    Thread.Sleep(200);
                    GetGeoCode(context, client, pramsUrl);
                }

                if(status != "OK")
                {
                    Console.WriteLine("ERROR: {0}", status);
                }
                else
                {
                    Console.WriteLine("SUCCESS: Results Count: {0}", readTask.Result.Results.Count());
                    geoCodes.Add(readTask.Result);
                }

            }).Wait();
        }
    }
}
