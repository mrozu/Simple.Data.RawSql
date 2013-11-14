using System;
using System.Collections.Generic;
using System.Linq;
using Simple.Data.Extensions;

namespace Simple.Data.RawSql
{
    public static class DatabaseToObjectsExtensions
    {
        public static IEnumerable<TResultType> ToObjects<TResultType>(this Database db, string sql,
                                                    IDictionary<string, object> parameters)
        {
            return db.ToRows(sql, parameters).Select(obj => (TResultType)obj);
        }

        public static IEnumerable<TResultType> ToObjects<TResultType>(this Database db, string sql,
                                                    params KeyValuePair<string, object>[] parameters)
        {
            return db.ToObjects<TResultType>(sql, parameters.ToDictionary());
        }

        public static IEnumerable<TResultType> ToObjects<TResultType>(this Database db, string sql, object parameters)
        {
            return db.ToObjects<TResultType>(sql, parameters.ObjectToDictionary());
        }
    }
}