using Microsoft.Extensions.DependencyInjection;
using TFProjectAPI.Client.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Patterns;

namespace TFProjectAPI.Client.Services
{
    public class ServiceLocator : ServLocator
    {
        private static ServiceLocator _instance;

        public static ServiceLocator Instance
        {
            get { return _instance ?? new ServiceLocator(); }
        }

        public ServiceLocator() { }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsersService<User>, UsersService>();
            serviceCollection.AddScoped<IGeneralTypeService<GeneralType>, GeneralTypesService>();
            serviceCollection.AddScoped<ICurrencyService<Currency>, CurrencyService>();
            serviceCollection.AddScoped<IMusicFormatService<MusicFormat>, MusicFormatService>();
            serviceCollection.AddScoped<IMusicTypeService<MusicType>, MusicTypeService>();
            serviceCollection.AddScoped<IShopService<Shop>, ShopService>();
            serviceCollection.AddScoped<ICurrency_Exchange<Currency_Exchange>, Currency_ExchangeService>();
            serviceCollection.AddScoped<IMusicService<Music>, MusicService>();
            serviceCollection.AddScoped<ICountryService<Country>, CountryService>();
        }

        public IUsersService<User> usersService
        {
            get { return Container.GetService<IUsersService<User>>(); }
        }

        public IShopService<Shop> shopService
        { 
          get { return Container.GetService<IShopService<Shop>>();  }
        }

        public IGeneralTypeService<GeneralType> GeneralTypeService
        {
            get { return Container.GetService<IGeneralTypeService<GeneralType>>();  }
        }

        public ICurrencyService<Currency> CurrencyService
        {
            get { return Container.GetService<ICurrencyService<Currency>>(); }
        }

        public IMusicFormatService<MusicFormat> MusicFormatService
        {
            get { return Container.GetService<IMusicFormatService<MusicFormat>>(); }
        }

        public IMusicTypeService<MusicType> MusicTypeService
        {
            get { return Container.GetService<IMusicTypeService<MusicType>>(); }
        }
        public ICurrency_Exchange<Currency_Exchange> Currency_ExchangeService
        {
            get { return Container.GetService<ICurrency_Exchange<Currency_Exchange>>(); }
        }

        public IMusicService<Music> MusicService
        {
            get { return Container.GetService<IMusicService<Music>>(); }
        }

        public ICountryService<Country> CountryService
        {
            get { return Container.GetService<ICountryService<Country>>(); }
        }

    }
}
