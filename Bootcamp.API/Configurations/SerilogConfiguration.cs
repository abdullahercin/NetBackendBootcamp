using System.Collections.ObjectModel;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace Bootcamp.API.Configurations
{
    public static class SerilogConfiguration
    {
        public static IServiceCollection AddSeriLogServices(this IServiceCollection services)
        {
            try
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json", false, true).AddEnvironmentVariables().Build();

                var _columnOptions = new ColumnOptions
                {
                    AdditionalColumns = new Collection<SqlColumn>
                    {
                        new SqlColumn {ColumnName="UserId"},
                        new SqlColumn {ColumnName="IpAddress"},
                        new SqlColumn {ColumnName="Controller"},
                        new SqlColumn {ColumnName="Action"},
                    }
                };
                _columnOptions.Store.Remove(StandardColumn.Properties);
                _columnOptions.Store.Add(StandardColumn.LogEvent);
                _columnOptions.Id.DataType = System.Data.SqlDbType.BigInt;

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Default", LogEventLevel.Error)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Error)
                    .MinimumLevel.Information()
                    .Filter.ByExcluding(logEvent =>
                        logEvent.Level == LogEventLevel.Information &&
                        logEvent.MessageTemplate.Text.Contains("HTTP"))
                    .Enrich.FromLogContext()
                    .WriteTo.MSSqlServer(config.GetSection("ConnectionStrings:SqlServer").Value,
                        sinkOptions: new MSSqlServerSinkOptions { TableName = "BootcampLog", AutoCreateSqlTable = false },// null, null, LogEventLevel.Information, null,
                        columnOptions: _columnOptions)
                    .CreateLogger();

                services.AddSerilog();

                return services;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Uygulama beklenmedik bir şekilde sonlandırıldı.");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return services;
        }
    }
}
