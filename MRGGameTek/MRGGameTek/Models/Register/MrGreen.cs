using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MRGGameTek.Models.Register
{
    public class MrGreen
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string PersonalNumber { get; set; }
        public void Validate(ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                modelState.AddModelError<MrGreen>(x => x.FirstName, "First Name is required.");
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                modelState.AddModelError<MrGreen>(x => x.LastName, "Last Name is required.");
            }
            if (string.IsNullOrWhiteSpace(PersonalNumber))
            {
                modelState.AddModelError<MrGreen>(x => x.PersonalNumber, "Personal Number is required.");
            }
            if (Address == null)
            {
                modelState.AddModelError<RedBet>(x => x.Address, "Address is required.");
            }
            else
            {
                Address.Validate(modelState);
            }
        }
    }
}
