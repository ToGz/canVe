namespace ProductsAPI.Integrations
{
    public interface ILookupClient
    {
        public void FindProductByKeywords(string search);
        public void FindProductByBarcode(string barcode);
    }
}
