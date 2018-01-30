﻿using System;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace PocketSql.Evaluation
{
    public static partial class Eval
    {
        public static EngineResult Evaluate(TSqlStatement statement, Env env)
        {
            switch (statement)
            {
                case SelectStatement select:
                    return Evaluate(select, env);
                case UpdateStatement update:
                    return Evaluate(update, env);
                case InsertStatement insert:
                    return Evaluate(insert, env);
                case DeleteStatement delete:
                    return Evaluate(delete, env);
                case MergeStatement merge:
                    return Evaluate(merge, env);
                case TruncateTableStatement truncate:
                    return Evaluate(truncate, env);
                case CreateTableStatement createTable:
                    return Evaluate(createTable, env);
                case DropObjectsStatement drop:
                    return Evaluate(drop, env);
                case SetVariableStatement set:
                    return Evaluate(set, env);
                case DeclareVariableStatement declare:
                    return Evaluate(declare, env);
                case IfStatement conditional:
                    return Evaluate(conditional, env);
                case WhileStatement loop:
                    return Evaluate(loop, env);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}