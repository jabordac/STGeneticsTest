using static System.Runtime.InteropServices.JavaScript.JSType;

namespace STGeneticsWeb.Models.Dtos;

public class PurchaseDto
{
    public Guid PurchaseId { get; set; }
    public List<PurchaseDetailDto> PurchaseDetails { get; set; }
    public int TotalItems { get; set; } = 0;
    public decimal SubTotalAmount { get; set; } = decimal.Zero;
    public decimal AdditionalDiscountPercentage { get; set; } = decimal.Zero;
    public decimal ShippingAmount { get; set; } = 1000;
    public decimal TotalAmount { get; set; } = decimal.Zero;


    public void RecalcTotalAmount()
    {
        TotalItems = PurchaseDetails.Count();
        SubTotalAmount = PurchaseDetails.Sum(x => x.TotalAmount);
        AdditionalDiscountPercentage = (TotalItems > 10) ? 3 : 0;
        ShippingAmount = (TotalItems > 20) ? 0 : 1000;

        TotalAmount = (SubTotalAmount - (SubTotalAmount * (AdditionalDiscountPercentage / 100))) + ShippingAmount;
    }
}
