using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookApp
{
    public class SQLHealthCheck : IHealthCheck
    {
        private string ConnectionString { get; }
        public SQLHealthCheck(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    var command = connection.CreateCommand();
                    command.CommandText = "select 1";
                    await command.ExecuteNonQueryAsync(cancellationToken);

                }
                catch (DbException ex)
                {
                    return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
                }
            }

            return HealthCheckResult.Healthy();
        }
    }
}
