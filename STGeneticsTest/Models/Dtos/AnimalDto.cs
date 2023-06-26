namespace STGeneticsWeb.Models.Dtos;

public class AnimalDto
{
    public Guid AnimalId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string BreedName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string Sex { get; set; }
    public decimal? Price { get; set; }
    public string Status { get; set; }
}