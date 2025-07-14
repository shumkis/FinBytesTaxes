namespace FinBytesTaxesAPI.Models.Dto
{
    public class UpdateCityTaxRuleDto
    {
        public decimal Rate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
