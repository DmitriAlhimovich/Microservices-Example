using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AsiaApp
{
    [Route("countries")]
    public class CountriesController
    {
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new List<string> { "China", "Japan", "Laos" };
        }
    }
}
