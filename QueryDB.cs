    class QueryDB
    {
        private string queryBuilder = "";

        private string connStr = "";

        public QueryDB Select(string? select = "")
        {
            if (select == null)
            {
                queryBuilder += "SELECT";
                return this;
            }

            queryBuilder += $"SELECT {select}";
            return this;
        }

        public QueryDB From(string table)
        {
            queryBuilder += $" FROM {table}";
            return this;
        }

        public QueryDB InsertInto(string table, string fields)
        {
            queryBuilder += $"INSERT INTO {table} ({fields})";
            return this;
        }

        public QueryDB Values(string values)
        {
            queryBuilder += $" VALUES ({values})";
            return this;
        }

        public QueryDB And(string col)
        {
            queryBuilder += $" AND {col}";
            return this;
        }

        public QueryDB DeleteFrom(string table)
        {
            queryBuilder += $" DELETE FROM {table}";
            return this;
        }

        public QueryDB Or(string col)
        {
            queryBuilder += $" OR {col}";
            return this;
        }

        public QueryDB Like(string param)
        {
            queryBuilder += $" LIKE '%{param}%'";
            return this;
        }

        public QueryDB All(string table)
        {
            queryBuilder += $"SELECT * FROM {table}";
            return this;
        }

        public QueryDB Update(string table)
        {
            queryBuilder += $"UPDATE {table}";
            return this;
        }

        public QueryDB Set(string field)
        {
            queryBuilder += $" SET {field}";
            return this;
        }

        public QueryDB SQL(string sql)
        {
            queryBuilder += $"{sql}";
            return this;
        }

        public QueryDB StoredProcedure(string sp)
        {
            queryBuilder += $"{sp}";
            return this;
        }

        public QueryDB Where(string str)
        {
            queryBuilder += $" WHERE {str}";
            return this;
        }

        public QueryDB Equals(string str)
        {
            queryBuilder += $" = '{str}'";
            return this;
        }

        public List<T> Get<T>(object? args = null, bool storedProcedure = false)
        {
            try
            {
                if(!storedProcedure)
                {
                    using (IDbConnection conn = new SqlConnection(connStr))
                    {
                        return conn.Query<T>(queryBuilder).ToList();
                    }
                }

                else
                {
                    using (IDbConnection conn = new SqlConnection(connStr))
                    {
                        return conn.Query<T>(queryBuilder, args ,commandType: CommandType.StoredProcedure).ToList();
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Exec()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connStr))
                {
                    conn.Execute(queryBuilder);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string QueryStr()
        {
            return queryBuilder;
        }
    }
