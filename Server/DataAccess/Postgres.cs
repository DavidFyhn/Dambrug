using Npgsql;

namespace DataAccess;

public static class Postgres
{
    public static NpgsqlDataSource CreateDataSource(string connectionString) =>
        NpgsqlDataSource.Create(connectionString);
}
