namespace FinBytesTaxesAPI.Models.Dto
{
    public class TaxScheduleItemDto
    {
        public DateOnly Date { get; set; }
        public decimal? Rate { get; set; }
    }
}
