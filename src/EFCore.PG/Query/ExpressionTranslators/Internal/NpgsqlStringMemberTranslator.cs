﻿using static Npgsql.EntityFrameworkCore.PostgreSQL.Utilities.Statics;

namespace Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

/// <summary>
/// Translates <see cref="M:string.Length"/> to 'length(text)'.
/// </summary>
public class NpgsqlStringMemberTranslator : IMemberTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public NpgsqlStringMemberTranslator(ISqlExpressionFactory sqlExpressionFactory)
        => _sqlExpressionFactory = sqlExpressionFactory;

    public virtual SqlExpression? Translate(SqlExpression? instance,
        MemberInfo member,
        Type returnType,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        => member.Name == nameof(string.Length) && instance?.Type == typeof(string)
            ? _sqlExpressionFactory.Convert(
                _sqlExpressionFactory.Function(
                    "length",
                    new[] { instance },
                    nullable: true,
                    argumentsPropagateNullability: TrueArrays[1],
                    typeof(long)),
                returnType)
            : null;
}