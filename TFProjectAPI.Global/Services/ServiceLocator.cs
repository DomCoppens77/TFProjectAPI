using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using TFProjectAPI.Global.Models;
using TFProjectAPI.Repo;
using TFProjectAPI.ToolBox.Database;
using TFProjectAPI.ToolBox.Patterns;

namespace TFProjectAPI.Global.Services
{
    public class ServiceLocator : ServLocator
    {
        private static ServiceLocator _instance;
        private IConfiguration _configuration;
        
        public static ServiceLocator Instance
        {
            get { return _instance ?? new ServiceLocator(); }
        }

        private ServiceLocator() {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Directory where the json files are located
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<DbProviderFactory, SqlClientFactory>((sp) => SqlClientFactory.Instance);
            serviceCollection.AddSingleton<IConnectionInfo, DBConnectionInfo>((sp) => new DBConnectionInfo(_configuration.GetSection("ConnectionStrings").GetSection("DBCONN").Value));
            serviceCollection.AddSingleton<IConnection, DBConnection>();

            serviceCollection.AddScoped<IUsersService<User>, UsersService>();

            serviceCollection.AddScoped<ICountryService<Country>, CountryService>();

            serviceCollection.AddScoped<IGeneralTypeService<GeneralType,GenYearPurch,GenObjectSearch>, GeneralTypesService>();
            serviceCollection.AddScoped<IShopService<Shop>, ShopService>();
            serviceCollection.AddScoped<ICurrencyService<Currency>, CurrencyService>();
            serviceCollection.AddScoped<ICurrency_Exchange<Currency_Exchange>, Currency_ExchangeService>();


            serviceCollection.AddScoped<IMusicTypeService<MusicType>, MusicTypeService>();
            serviceCollection.AddScoped<IMusicFormatService<MusicFormat>, MusicFormatService>();
            serviceCollection.AddScoped<IMusicService<Music>, MusicService>();

            serviceCollection.AddScoped<ICodeMstrService<Code_Mstr>, CodeMstrService>();

        }

        internal IConnection Connection
        {
            get { return Container.GetService<IConnection>(); }
        }

        public IUsersService<User> UsersService
        {
            get { return Container.GetService<IUsersService<User>>(); }
        }
        public IShopService<Shop> ShopService
        {
            get { return Container.GetService<IShopService<Shop>>(); }
        }

        public IGeneralTypeService<GeneralType, GenYearPurch, GenObjectSearch> GeneralTypeService
        { 
            get { return Container.GetService<IGeneralTypeService<GeneralType, GenYearPurch,GenObjectSearch >> (); }
        }
        public ICurrencyService<Currency> CurrencyService
        {
            get { return Container.GetService<ICurrencyService<Currency>>(); }
        }

        public IMusicTypeService<MusicType> MusicTypeService
        {
            get { return Container.GetService<IMusicTypeService<MusicType>>(); }
        }
        public IMusicFormatService<MusicFormat> MusicFormatService
        {
            get { return Container.GetService<IMusicFormatService<MusicFormat>>(); }
        }

        public IMusicService<Music> MusicService
        {
            get { return Container.GetService<IMusicService<Music>>(); }
        }

        public ICurrency_Exchange<Currency_Exchange> Currency_ExchangeService
        {

            get { return Container.GetService<ICurrency_Exchange<Currency_Exchange>>(); }

        }
        public ICountryService<Country> CountryService
        {
            get { return Container.GetService<ICountryService<Country>>(); }
        }

        public ICodeMstrService<Code_Mstr> CodeMstrService
        {
            get { return Container.GetService<ICodeMstrService<Code_Mstr>>(); }
        }
    }
}
