using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GlobalApp
{
    [Route("allCountries")]
    public class CountriesController
    {
        public async Task<string> GetAllCountries()
        {
            var asiaEndPoint = "http://localhost:11111";
            var asiaCountriesPath = "countries";
            var europeEndPoint = "http://localhost:22222";
            var europeCountriesPath = "countriesList";

            var asiaCountries = await GetFromApi(asiaEndPoint, asiaCountriesPath);
            var europeCountries = await GetFromApi(europeEndPoint, europeCountriesPath);

            return string.Join("\n",
                asiaCountries.Select(c => CountryWithContinent(c, "Asia")).Concat(europeCountries.Select(c => CountryWithContinent(c, "Europe")))
                .OrderBy(c => c));
        }

        private string CountryWithContinent(string country, string continent) => $"{country} ({continent})";

        private async Task<IEnumerable<string>> GetFromApi(string endPoint, string localPath)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(string.Join("/", endPoint, localPath));

            return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
        }
    }
}
