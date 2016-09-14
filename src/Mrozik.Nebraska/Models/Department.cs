namespace Mrozik.Nebraska.Models
{
    public class Department
    {

        private Department() { }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
    }
}