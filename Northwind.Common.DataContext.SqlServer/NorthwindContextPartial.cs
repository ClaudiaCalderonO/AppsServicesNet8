using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public partial class NorthwindContext
{
    private static readonly SetLastRefreshedInterceptor
      setLastRefreshedInterceptor = new();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            SqlConnectionStringBuilder builder = new();

            builder.DataSource = "Claudia-PC\\MSSQLSERVER01";
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            // Because we want to fail fast. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            // If using Windows Integrated authentication.
            builder.IntegratedSecurity = true;

            // If using SQL Server authentication.
            // builder.UserID = Environment.GetEnvironmentVariable("MY_SQL_USR");
            // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }

        optionsBuilder.AddInterceptors(setLastRefreshedInterceptor);
    }
}
