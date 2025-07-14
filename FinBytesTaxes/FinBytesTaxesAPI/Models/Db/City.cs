namespace FinBytesTaxesAPI.Models.Db
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<CityTaxRule> TaxRules { get; set; } = [];
    }
}
