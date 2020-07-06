using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MRGGameTek.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public void Validate(ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(Street))
            {
                modelState.AddModelError<Address>(x => x.Street, "Street is required.");
            }
            if (string.IsNullOrWhiteSpace(City))
            {
                modelState.AddModelError<Address>(x => x.City, "City is required.");
            }
            if (string.IsNullOrWhiteSpace(State))
            {
                modelState.AddModelError<Address>(x => x.State, "State is required.");
            }
            if (string.IsNullOrWhiteSpace(Country))
            {
                modelState.AddModelError<Address>(x => x.Country, "Country is required.");
            }
        }
    }
}
