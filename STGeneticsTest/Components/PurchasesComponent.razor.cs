namespace STGeneticsWeb.Components;

using Microsoft.AspNetCore.Components;
using MudBlazor;
using STGeneticsWeb.Models.Dtos;
using System.Reflection.Metadata;

public partial class PurchasesComponent
{
    [Parameter] public List<PurchaseDetailDto> PurchaseDetails { get; set; }

    private MudTable<PurchaseDetailDto> PurchasedAnimalsTable;
    private IEnumerable<PurchaseDetailDto> PurchasedAnimalsPagedData;
    private PurchaseDto PurchaseData = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            await PurchasedAnimalsTable.ReloadServerData();
        }
    }

    private TableGroupDefinition<PurchaseDetailDto> BreedGroupDefinition = new()
    {
        GroupName = "Breed",
        Indentation = true,
        Expandable = false,
        Selector = (e) => e.Animal.BreedName
    };

    private async Task<TableData<PurchaseDetailDto>> PurchasedAnimalsReload(TableState state)
    {
        IEnumerable<PurchaseDetailDto> data = PurchaseDetails;

        PurchaseData.PurchaseDetails = PurchaseDetails;
        PurchaseData.RecalcTotalAmount();

        switch (state.SortLabel)
        {
            case "Code":
                data = data.OrderByDirection(state.SortDirection, o => o.Animal.Code);
                break;
            case "Name":
                data = data.OrderByDirection(state.SortDirection, o => o.Animal.Name);
                break;
            case "BreedName":
                data = data.OrderByDirection(state.SortDirection, o => o.Animal.BreedName);
                break;
            case "Sex":
                data = data.OrderByDirection(state.SortDirection, o => o.Animal.Sex);
                break;
            case "Price":
                data = data.OrderByDirection(state.SortDirection, o => o.Animal.Price);
                break;
        }

        PurchasedAnimalsPagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();

        return new TableData<PurchaseDetailDto>() { TotalItems = PurchaseData.TotalItems, Items = PurchasedAnimalsPagedData };
    }

    private void IncrementQuantity_OnChanged(PurchaseDetailDto item)
    {
        item.DiscountPercentage = (item.Quantity > 5) ? 5 : 0;
        item.RecalcTotalAmount();

        PurchaseData.RecalcTotalAmount();
    }

}