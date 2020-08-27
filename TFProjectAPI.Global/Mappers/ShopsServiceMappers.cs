using System.Data;
using TFProjectAPI.Global.Models;

namespace TFProjectAPI.Global.Mappers
{
    internal static class ShopsServiceMappers
    {
        internal static Shop ToShop(this IDataRecord dataRecord)
        {
            return new Shop()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"],
                Address1 = (string)dataRecord["Address1"],
                Address2 = (string)dataRecord["Address2"],
                ZIP = (string)dataRecord["ZIP"],
                City = (string)dataRecord["City"],
                Country = (string)dataRecord["Country"],
                Phone = (string)dataRecord["Phone"],
                Email = (string)dataRecord["Email"],
                WebSite = (string)dataRecord["WebSite"],
                LocalisationURL = (string)dataRecord["LocalisationURL"],
                Closed = (bool)dataRecord["Closed"]
            };
        }

    }
}
