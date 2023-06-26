namespace STGeneticsWeb.Models.Dtos;

public class PurchaseDetailDto
{
    public Guid PurchaseDetailId { get; set; }
    public AnimalDto Animal { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal SubTotalAmount { get; set; } = decimal.Zero;
    public decimal DiscountPercentage { get; set; } = decimal.Zero;
    public decimal TotalAmount { get; set; } = decimal.Zero;

    public void RecalcTotalAmount()
    {
        if(Animal != null)
        {
            SubTotalAmount = Animal.Price!.Value * Quantity;
            TotalAmount = SubTotalAmount - (SubTotalAmount * (DiscountPercentage / 100));
        }
    }
}
