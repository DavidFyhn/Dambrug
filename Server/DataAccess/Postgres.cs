using System.Security.Cryptography.X509Certificates;
using Npgsql;

namespace DataAccess;

public static class Postgres
{
    public static NpgsqlDataSource CreateDataSource(string connectionString)
    {
        var settings = new NpgsqlConnectionStringBuilder(connectionString)
        {
            SslMode = SslMode.VerifyFull,
            CheckCertificateRevocation = false
        };

        var builder = new NpgsqlDataSourceBuilder(settings.ConnectionString);

        builder.UseSslClientAuthenticationOptionsCallback(options =>
        {
            options.CertificateChainPolicy ??= new X509ChainPolicy();
            options.CertificateChainPolicy.RevocationMode =
                X509RevocationMode.NoCheck;
        });

        return builder.Build();
    }
}