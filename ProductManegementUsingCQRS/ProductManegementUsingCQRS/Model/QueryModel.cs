namespace ProductManegementUsingCQRS.Model
{
    public class QueryModel
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
