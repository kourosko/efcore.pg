﻿namespace Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;

public class NpgsqlExecutionStrategyFactory : RelationalExecutionStrategyFactory
{
    public NpgsqlExecutionStrategyFactory(
        ExecutionStrategyDependencies dependencies)
        : base(dependencies)
    {
    }

    protected override IExecutionStrategy CreateDefaultStrategy(ExecutionStrategyDependencies dependencies)
        => new NpgsqlExecutionStrategy(dependencies);
}