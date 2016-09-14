using System;

namespace Mrozik.Nebraska.Models
{
    public class Order
    {
        private Order() { }

        public int Id { get; private set; }
        public string Number { get; private set; }
        public byte Progress { get; private set; }
        public string ProgressColorRgb { get; private set; }
        public int Priority { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime DeadlineDate { get; private set; }
        public string Content { get; private set; }
        public string Remarks { get; private set; }
        public string Amount { get; private set; }
        public string Colors { get; private set; }
        public string ProgressDescription { get; private set; }
        public int Departments { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}