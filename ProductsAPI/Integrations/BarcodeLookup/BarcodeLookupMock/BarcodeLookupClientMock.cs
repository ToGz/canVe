using Newtonsoft.Json;

namespace ProductsAPI.Integrations.BarcodeLookup.BarcodeLookupMock
{
    public class BarcodeLookupClientMock
    {
        public async void FindProductByKeywords(string search)
        {
            SearchLocalMockRepo(search);
        }

        public async void FindProductByBarcode(string barcode)
        {
            SearchLocalMockRepo(barcode);
        }

        private BarcodeLookupContract SearchLocalMockRepo(string search)
        {
            var files = Directory.GetFiles("Integrations/BarcodeLookup/BarcodeLookupMock/ResultsMock");

            var res = files
                .Where(f => Path.GetFileNameWithoutExtension(f).Contains(search))
                .OrderBy(f => f.Length)
                .FirstOrDefault();

            if (res is null)
                return new BarcodeLookupContract();

            using var r = new StreamReader(res);

            string json = r.ReadToEnd();
            var items = JsonConvert.DeserializeObject<BarcodeLookupContract>(json);

            return items;
        }
    }
}
