namespace FinBytesTaxesAPI.Helpers
{
    public static class DateHelper
    {
        public static List<DateOnly> RangeToDateList(DateOnly from, DateOnly to)
        {
            var range = new List<DateOnly>();

            if (to < from)
            {
                return range;
            }

            while (from <= to)
            {
                range.Add(from);
                from = from.AddDays(1);
            }

            return range;
        }
    }
}
