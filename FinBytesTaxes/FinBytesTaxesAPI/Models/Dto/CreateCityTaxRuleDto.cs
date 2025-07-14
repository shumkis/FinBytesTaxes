namespace FinBytesTaxesAPI.Models.Dto
{
    public class CreateCityTaxRuleDto
    {
        public int CityId { get; set; }
        public int TaxTypeId { get; set; }
        public decimal Rate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
