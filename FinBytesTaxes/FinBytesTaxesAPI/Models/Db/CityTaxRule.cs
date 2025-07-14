using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Models.Db
{
    [Index(nameof(StartDate), nameof(EndDate))]
    public class CityTaxRule
    {
        public int Id { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; } = null!;

        public decimal Rate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
