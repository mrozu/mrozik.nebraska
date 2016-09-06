using System;
using System.Collections.Generic;

namespace Mrozik.Nebraska.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
        public string Departments { get; set; }
        public string Quantity { get; set; }
        public string Colors { get; set; }
        public string RealisationDetails { get; set; }

    }
}