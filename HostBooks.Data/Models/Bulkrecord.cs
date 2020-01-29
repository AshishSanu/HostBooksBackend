﻿using System;
using System.Collections.Generic;

namespace HostBooks.Data.Models
{
    public partial class Bulkrecord
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string ItemType { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public string OrderId { get; set; }
        public int? UnitsSold { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? TotalProfit { get; set; }
        public string ShipDate { get; set; }
        public string OrderDate { get; set; }
    }
}
