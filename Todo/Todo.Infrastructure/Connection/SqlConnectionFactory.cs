using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Threading;
using System.Linq;

namespace Todo.Backend.Infrastructure.Connection
{
    public class SqlConnectionFactory
    {
        private readonly string connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var con = new SqlConnection(connectionString);
            await con.OpenAsync();
            return con;
        }

        public async Task<T> StoredProcedureFirstAsync<T>(string procedure, object parameters, CancellationToken cancellationToken, bool returnFirst = false)
        {
            var res = await ExecuteStoredProcedureAsync<T>(procedure, parameters, cancellationToken);

            return res.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> StoredProcedureAsync<T>(string procedure, object parameters, CancellationToken cancellationToken, bool returnFirst = false)
        {
            var res = await ExecuteStoredProcedureAsync<T>(procedure, parameters, cancellationToken);

            return res;
        }

        public async Task StoredProcedureAsync(string procedure, object parameters, CancellationToken cancellationToken)
        {
            await ExecuteStoredProcedureAsync<object>(procedure, parameters, cancellationToken);
        }

        private async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string procedure, object parameters, CancellationToken cancellationToken)
        {
            using var con = await CreateConnectionAsync();

            var cmd = new CommandDefinition(procedure, parameters, cancellationToken: cancellationToken, commandType: CommandType.StoredProcedure);

            if (typeof(T).Equals(typeof(object)))
            {
                await con.QueryAsync(cmd);

                return new List<T>();
            } else
            {
                return await con.QueryAsync<T>(cmd);
            }
        }
    }

    public static class SqlConnectionFactoryExtension
    {
        public static void AddSqlFactory(this IServiceCollection serviceCollection, Func<IConfiguration, string> connectionString)
        {
            serviceCollection.AddTransient(provider =>
            {
                return new SqlConnectionFactory(connectionString(provider.GetRequiredService<IConfiguration>()));
            });
        }
    }
}
