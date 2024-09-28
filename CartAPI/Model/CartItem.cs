namespace CartAPI.Model
{
    public class CartItem
    {
        public int ProdId { get; set; }
        public string Name { get; set; }
        public int Amt { get; set; }
        public decimal Qnt { get; set; }
        public string Img { get; set; }
    }
}
