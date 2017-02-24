using Dapper.Contrib.Extensions;
using System;

namespace Tibox.Models
{
    [Table("[Order]")]
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }        
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }        
    }
}
