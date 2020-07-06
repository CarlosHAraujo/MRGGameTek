using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace MRGGameTek.Models.Register
{
    public class RedBet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        //To become a list in DB
        public string FavoriteFootballTeam { get; set; }

        internal void Validate(ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                modelState.AddModelError<RedBet>(x => x.FirstName, "First Name is required.");
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                modelState.AddModelError<RedBet>(x => x.LastName, "Last Name is required.");
            }
            if (string.IsNullOrWhiteSpace(FavoriteFootballTeam))
            {
                modelState.AddModelError<RedBet>(x => x.FavoriteFootballTeam, "Favority Team is required.");
            }
            if(Address == null)
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
