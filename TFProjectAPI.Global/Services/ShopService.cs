using System.Collections.Generic;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class ShopService : IShopService<Shop>
    {
        public Shop Add(Shop shop)
        {
            DBCommand command = new DBCommand("[AppUser].[AddShop]", true);
            command.AddParameter("Name", shop.Name);
            command.AddParameter("Address1", shop.Address1);
            command.AddParameter("Address2", shop.Address2);
            command.AddParameter("ZIP", shop.ZIP);
            command.AddParameter("City", shop.City);
            command.AddParameter("Country", shop.Country);
            command.AddParameter("Phone", shop.Phone);
            command.AddParameter("Email", shop.Email);
            command.AddParameter("WebSite", shop.WebSite);
            command.AddParameter("LocalisationURL", shop.LocalisationURL);
            command.AddParameter("closed", shop.Closed);
            shop.Id = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return shop;
        }

        public bool Del(int id)
        {
            DBCommand command = new DBCommand("[AppUser].[DelShop]", true);
            command.AddParameter("Id", id);

            return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Shop> Get()
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Shops];");
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToShop());
        }

        public Shop Get(int id)
        {
            DBCommand command = new DBCommand("Select * From [AppUser].[V_Shops] Where [Id] = @Id;");
            command.AddParameter("Id", id);
            return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToShop()).SingleOrDefault();
        }

        public int ShopIsUsed(int id)
        {
            //DBCommand command = new DBCommand("[AppUser].[CheckShop]", true);
            //command.AddParameter("Id", id);

            DBCommand command = new DBCommand("SELECT COUNT(*) FROM [AppUser].[V_Object] where [ShopId] = @Id; ");
            command.AddParameter("Id", id);
            int i = (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            return i;
        }

        public bool Upd(Shop shop)
        {
            DBCommand command = new DBCommand("[AppUser].[UpdShop]", true);
            command.AddParameter("Id", shop.Id);
            command.AddParameter("Name", shop.Name);
            command.AddParameter("Address1", shop.Address1);
            command.AddParameter("Address2", shop.Address2);
            command.AddParameter("ZIP", shop.ZIP);
            command.AddParameter("City", shop.City);
            command.AddParameter("Country", shop.Country);
            command.AddParameter("Phone", shop.Phone);
            command.AddParameter("Email", shop.Email);
            command.AddParameter("WebSite", shop.WebSite);
            command.AddParameter("LocalisationURL", shop.LocalisationURL);
            command.AddParameter("closed", shop.Closed);
            
            return 1 == ServiceLocator.Instance.Connection.ExecuteNonQuery(command);
        }
    }
}
