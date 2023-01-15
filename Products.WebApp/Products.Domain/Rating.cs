namespace Products.Domain
{
    public class Rating : BaseEntity
    {
        public decimal Rate { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
