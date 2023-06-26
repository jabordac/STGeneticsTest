﻿namespace STGeneticsWeb.Components;

using MudBlazor;
using STGeneticsWeb.Models.Dtos;
using Microsoft.AspNetCore.Components;

public partial class AnimalsComponent
{
    [Parameter] public EventCallback<HashSet<AnimalDto>> OnSelectedAnimals { get; set; }


    //private IEnumerable<AnimalDto> Animals = new List<AnimalDto>();

    private MudTable<AnimalDto> AnimalsTable;
    private IEnumerable<AnimalDto> AnimalsPagedData;
    private AnimalDto AnimalFilters = new AnimalDto();
    private int animalsTotalItems;
    private decimal animalsTotalPrice;
    private int selectedTotalItems;
    private decimal selectedTotalPrice;

    protected override async Task OnInitializedAsync()
    {
        //await AnimalsTable.ReloadServerData();
    }

    private async Task ApplyFilter_OnClick()
    {
        await AnimalsTable.ReloadServerData();
    }

    private async Task AddSelectedAnimal_OnClick(AnimalDto item)
    {
        AnimalsTable.SelectedItems.Add(item);
        await AddSelectedAnimals_OnClick();
    }

    private async Task AddSelectedAnimals_OnClick()
    {
        await OnSelectedAnimals.InvokeAsync(AnimalsTable.SelectedItems);
        AnimalsTable.SelectedItems.Clear();
    }

    private async Task SelectedAnimals_OnChanged(HashSet<AnimalDto> items)
    {
        selectedTotalItems = items.Count();
        selectedTotalPrice = items.Sum(x => x.Price).GetValueOrDefault(0);
    }

    private async Task<TableData<AnimalDto>> AnimalsReload(TableState state)
    {
        IEnumerable<AnimalDto> data = GetAnimalsData();
        //await httpClient.GetFromJsonAsync<List<Element>>("webapi/periodictable");

        data = data.Where(element =>
        {
            if (AnimalFilters.Code == null && string.IsNullOrEmpty(AnimalFilters.Name) && string.IsNullOrEmpty(AnimalFilters.BreedName)
               && AnimalFilters.BirthDate == null && string.IsNullOrEmpty(AnimalFilters.Sex) && AnimalFilters.Price == null
               && AnimalFilters.Status == null)
                return true;

            if (AnimalFilters.Code != null && element.Code.Equals(AnimalFilters.Code))
                return true;

            if (!string.IsNullOrEmpty(AnimalFilters.Name) && element.Name.Contains(AnimalFilters.Name!, StringComparison.OrdinalIgnoreCase))
                return true;

            if (!string.IsNullOrEmpty(AnimalFilters.BreedName) && element.BreedName.Contains(AnimalFilters.BreedName!, StringComparison.OrdinalIgnoreCase))
                return true;

            if (element.BirthDate != null && element.BirthDate!.Equals(AnimalFilters.BirthDate))
                return true;

            if (!string.IsNullOrEmpty(AnimalFilters.Sex) && element.Sex.Equals(AnimalFilters.Sex))
                return true;

            if (element.Price != null && element.Price <= AnimalFilters.Price)
                return true;

            if (AnimalFilters.Status != null && element.Status.Equals(AnimalFilters.Status))
                return true;

            return false;
        }).ToArray();

        animalsTotalItems = data.Count();
        animalsTotalPrice = data.Sum(x => x.Price).GetValueOrDefault(0);

        switch (state.SortLabel)
        {
            case "Code":
                data = data.OrderByDirection(state.SortDirection, o => o.Code);
                break;
            case "Name":
                data = data.OrderByDirection(state.SortDirection, o => o.Name);
                break;
            case "BreedName":
                data = data.OrderByDirection(state.SortDirection, o => o.BreedName);
                break;
            case "BirthDate":
                data = data.OrderByDirection(state.SortDirection, o => o.BirthDate);
                break;
            case "Sex":
                data = data.OrderByDirection(state.SortDirection, o => o.Sex);
                break;
            case "Price":
                data = data.OrderByDirection(state.SortDirection, o => o.Price);
                break;
            case "Status":
                data = data.OrderByDirection(state.SortDirection, o => o.Status);
                break;
        }

        AnimalsPagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();

        return new TableData<AnimalDto>() { TotalItems = animalsTotalItems, Items = AnimalsPagedData };
    }

    private List<AnimalDto> GetAnimalsData()
    {
        return new List<AnimalDto>()
        {
            new AnimalDto {
                AnimalId = Guid.NewGuid(),
                Code = "001",
                Name = "Test 1",
                BreedName = "Breed 1",
                BirthDate = DateTime.Now,
                Price = 1000,
                Sex = "M",
                Status = 1
            },
            new AnimalDto {
                AnimalId = Guid.NewGuid(),
                Code = "002",
                Name = "Test 2",
                BreedName = "Breed 2",
                BirthDate = DateTime.Now,
                Price = 2500,
                Sex = "F",
                Status = 1
            },
            new AnimalDto {
                AnimalId = Guid.NewGuid(),
                Code = "003",
                Name = "Test 3",
                BreedName = "Breed 3",
                BirthDate = DateTime.Now,
                Price = 1500,
                Sex = "M",
                Status = 1
            },
            new AnimalDto {
                AnimalId = Guid.NewGuid(),
                Code = "004",
                Name = "Test 4",
                BreedName = "Breed 4",
                BirthDate = DateTime.Now,
                Price = 3400,
                Sex = "F",
                Status = 1
            },
            new AnimalDto {
                AnimalId = Guid.NewGuid(),
                Code = "005",
                Name = "Test 5",
                BreedName = "Breed 5",
                BirthDate = DateTime.Now,
                Price = 1800,
                Sex = "F",
                Status = 1
            }
        };
    }

}