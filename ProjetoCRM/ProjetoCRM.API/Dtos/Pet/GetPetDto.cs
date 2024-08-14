using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRM.API.Dtos.Pet;

public class GetPetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Specie { get; set; }
    public string Race { get; set; }
    
    public PetOwnerDto Owner { get; set; }
}

public class PetOwnerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}