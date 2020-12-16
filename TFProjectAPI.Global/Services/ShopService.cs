using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFProjectAPI.Global.Mappers;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;

namespace TFProjectAPI.Global.Services
{
    public class ShopService : IShopService<Shop>
    {
        private string where = "GS";
        private string Str_Get = "Select * From [AppUser].[V_Shops]";

        public IEnumerable<Shop> Get()
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " ORDER BY [Country], [Name] " + ";");
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToShop());
            }
            catch (Exception e) { throw e; }
        }

        public Shop Get(int id)
        {
            try
            {
                DBCommand command = new DBCommand(Str_Get + " Where [Id] = @Id;");
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteReader(command, dr => dr.ToShop()).SingleOrDefault();
            }
            catch (Exception e) { throw e; }
        }

        public Shop Add(Shop shop)
        {
            try
            {
                if (shop is null) throw new DataException("Shop Data empty (" + where + ") (ADD)");

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
            catch (Exception e) { throw e; }
        }

        public bool Upd(Shop shop)
        {
            try
            {
                if (shop is null) throw new DataException("Shop Data empty (" + where + ") (UPD)");

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
            catch (Exception e) { throw e; }
        }
        public bool Del(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[DelShop]", true);
                command.AddParameter("Id", id);
                return ServiceLocator.Instance.Connection.ExecuteNonQuery(command) == 1;
            }
            catch (Exception e) { throw e; }
        }

        public int ShopIsUsed(int id)
        {
            try
            {
                DBCommand command = new DBCommand("[AppUser].[CheckShop]", true);
                command.AddParameter("Id", id);
                return (int)ServiceLocator.Instance.Connection.ExecuteScalar(command);
            }
            catch (Exception e) { throw e; }
        }
    }
}
