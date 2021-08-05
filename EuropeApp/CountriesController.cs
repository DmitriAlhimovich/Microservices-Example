using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EuropeApp
{
    [Route("countriesList")]
    public class CountriesController
    {
        public IEnumerable<string> GetCountries()
        {
            return new List<string> { "Italy", "France", "Greece" };
        }
    }
}
