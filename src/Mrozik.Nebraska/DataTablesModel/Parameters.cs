using System;
using System.Collections.Generic;
using Mrozik.Nebraska.Models;

namespace Mrozik.Nebraska.DataTablesModel
{
    public class Parameters
    {
        public int Draw { get; set; }

        public int Start { get; set; }
        public int Length { get; set; }

        public IList<ColumnOrder/*Dictionary<string, string>*/> Order { get; set; }
        public IList<Column/*Dictionary<string, string>*/> Columns { get; set; }

        public Filters Filters { get; set; }
    }

    public class Filters
    {
        public string Search { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ScansAvailability ScansAvailability { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string DepartmentName { get; set; }
    }

    public enum OrderStatus
    {
        All,
        InProgress,
        Done
    }

    public enum ScansAvailability
    {
        All,
        WithScans,
        WithoutScans
    }
}