﻿using System;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace PocketSql.Evaluation
{
    public static partial class Eval
    {
        public static EngineResult Evaluate(InsertSpecification insert, Env env)
        {
            var namedTableRef = (NamedTableReference)insert.Target;
            var table = env.Engine.Tables[namedTableRef.SchemaObject.BaseIdentifier.Value];

            switch (insert.InsertSource)
            {
                case ValuesInsertSource values:
                    return Evaluate(table, insert.Columns, values, env);
                case SelectInsertSource select:
                    return Evaluate(table, insert.Columns, Evaluate(select.Select, env).ResultSet, env);
            }

            throw new NotImplementedException();
        }
    }
}