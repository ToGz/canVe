
public class BarcodeLookupContract
{
    public BarcodeLookupProduct[] products { get; set; }
}

public class BarcodeLookupProduct
{
    public string barcode_number { get; set; }
    public string barcode_formats { get; set; }
    public string mpn { get; set; }
    public string model { get; set; }
    public string asin { get; set; }
    public string title { get; set; }
    public string category { get; set; }
    public string manufacturer { get; set; }
    public string brand { get; set; }
    public object[] contributors { get; set; }
    public string age_group { get; set; }
    public string ingredients { get; set; }
    public string nutrition_facts { get; set; }
    public string energy_efficiency_class { get; set; }
    public string color { get; set; }
    public string gender { get; set; }
    public string material { get; set; }
    public string pattern { get; set; }
    public string format { get; set; }
    public string multipack { get; set; }
    public string size { get; set; }
    public string length { get; set; }
    public string width { get; set; }
    public string height { get; set; }
    public string weight { get; set; }
    public string release_date { get; set; }
    public string description { get; set; }
    public object[] features { get; set; }
    public string[] images { get; set; }
    public string last_update { get; set; }
    public BarcodeLookupStore[] stores { get; set; }
    public object[] reviews { get; set; }
}

public class BarcodeLookupStore
{
    public string name { get; set; }
    public string country { get; set; }
    public string currency { get; set; }
    public string currency_symbol { get; set; }
    public string price { get; set; }
    public string sale_price { get; set; }
    public object[] tax { get; set; }
    public string link { get; set; }
    public string item_group_id { get; set; }
    public string availability { get; set; }
    public string condition { get; set; }
    public object[] shipping { get; set; }
    public string last_update { get; set; }
}
