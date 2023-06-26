namespace STGeneticsWeb.Pages;

using MudBlazor;
using STGeneticsWeb.Models.Dtos;

public partial class SalesManager
{
    private List<PurchaseDetailDto> PurchaseDetails = new List<PurchaseDetailDto>();

    private void SelectedAnimals_OnChanged(HashSet<AnimalDto> selectedAnimals)
    {
        if (selectedAnimals.Any())
        {
            foreach (var animal in selectedAnimals)
            {
                if(animal.Status == "Inactive")
                {

                }   
                else if(PurchaseDetails.Any(x => x.Animal.AnimalId == animal.AnimalId))
                {

                }
                else
                {
                    PurchaseDetailDto item = new PurchaseDetailDto
                    {
                        PurchaseDetailId = Guid.NewGuid(),
                        Animal = animal,
                        Quantity = 1
                    };

                    PurchaseDetails.Add(item);
                }
            }
        }
    }

}