using TFProjectAPI.Client.Models;
using GM = TFProjectAPI.Global.Models;

namespace TFProjectAPI.Client.Mappers
{
    internal static class ShopServiceMappers
    {

        internal static GM.Shop ToGlobal(this Shop s)
        {
            return new GM.Shop() { Id = s.Id, Name = s.Name, Address1 = s.Address1, Address2 = s.Address2, ZIP = s.ZIP, City = s.City, Country = s.Country, Phone = s.Phone, Email = s.Email, WebSite = s.WebSite, LocalisationURL = s.LocalisationURL, Closed = s.Closed };
        }

        internal static Shop ToClient(this GM.Shop s)
        {
            if (s is null) return null;
            else
                return new Shop(s.Id, s.Name, s.Address1, s.Address2, s.ZIP, s.City, s.Country, s.Phone, s.Email, s.WebSite, s.LocalisationURL, s.Closed);

        }

    }
}
