namespace films_api.Dtos;

public class CreateAddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string ZipOrPostalCode { get; set; }
    public string Country { get; set; }
}