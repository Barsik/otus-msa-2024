using Npgsql;

namespace Obavi.Common;

public static class ConnectionStringBuilder
{
    public static string Build(IConfiguration configuration)
    {
        var host = configuration["Database:Host"];
        var port = configuration.GetValue<int>("Database:Port");
        var name = configuration["Database:Name"];
        var userName = configuration["Database:Username"];
        var password = configuration["Database:Password"];
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = host,
            Port = port,
            Database = name,
            Username = userName,
            Password = password,
            Pooling = true,
            ConnectionLifetime = 0,
        };

        return builder.ConnectionString;
    }
}