using System;
using System.IO;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;

namespace BookingLibrary.Service.Handler
{
    public class AppsettingInventoryReadDBConnectionStringProvider : IInventoryReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingInventoryReadDBConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return _configuration["inventoryReadDBConnectionString"];
            }
        }
    }

    public class AppsettingInventoryWriteDBConnectionStringProvider : IInventoryWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingInventoryWriteDBConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return _configuration["inventoryWriteDBConnectionString"];
            }
        }
    }

    public class AppsettingRentalReadDBConnectionStringProvider : IRentalReadDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingRentalReadDBConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return _configuration["rentalReadDBConnectionString"];
            }
        }
    }

    public class AppsettingRentalWriteDBConnectionStringProvider : IRentalWriteDBConnectionStringProvider
    {
        private IConfigurationRoot _configuration = null;

        public AppsettingRentalWriteDBConnectionStringProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public string ConnectionString
        {
            get
            {
                return _configuration["rentalWriteDBConnectionString"];
            }
        }
    }
}