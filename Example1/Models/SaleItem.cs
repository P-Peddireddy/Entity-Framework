using System;

namespace Example1.Models
{
    public class SaleItem
    {
        public long Price { get; set; }
        public string SaleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
