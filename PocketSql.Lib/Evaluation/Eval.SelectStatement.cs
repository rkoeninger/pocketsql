﻿using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace PocketSql.Evaluation
{
    public static partial class Eval
    {
        public static EngineResult Evaluate(SelectStatement select, Env env)
        {
            var results = Evaluate(select.QueryExpression, env);

            if (select.Into != null)
            {
                env.Engine.tables.Add(select.Into.Identifiers.Last().Value, results.ResultSet);

                return new EngineResult
                {
                    RecordsAffected = results.ResultSet.Rows.Count
                };
            }

            return results;
        }
    }
}