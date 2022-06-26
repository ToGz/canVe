using Flurl;
using Flurl.Http;

namespace ProductsAPI.Integrations
{
    public class BarcodeLookupClient
    {
        private string _BaseUrl { get; } = "https://api.barcodelookup.com/v3";
        private string _Key { get; }

        public BarcodeLookupClient(IConfiguration configuration)
        {
            _Key = configuration["BarcodeKey"];
        }

        public async void FindProductByKeywords(string search)
        {
            var result = await _BaseUrl
                .AppendPathSegment("products")
                .SetQueryParams(new
                {        
                    key = _Key,
                    category = "Food, Beverages & Tobacco > Food Items",
                    formatted = "y",
                    search
                })
                .GetJsonAsync<Rootobject>();
        }

        public async void FindProductByBarcode(string barcode)
        {
            var result = await _BaseUrl
                .AppendPathSegment("products")
                .SetQueryParams(new
                {
                    key = _Key,
                    category = "Food, Beverages & Tobacco > Food Items",
                    formatted = "y",
                    barcode
                })
                .GetJsonAsync<Rootobject>();
        }
    }
}
