using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Models.Db
{
    [Index(nameof(Priority))]
    public class TaxType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Priority { get; set; }
    }
}
