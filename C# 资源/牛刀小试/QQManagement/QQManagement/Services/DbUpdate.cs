using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QQManagement.Services.baseDbhelp;

namespace QQManagement.Services
{
    internal class DbUpdate
    {
        private StringBuilder sb = new StringBuilder();
        private StringBuilder where = new StringBuilder();
        private List<DbParameter> pars = new List<DbParameter>();
        private DbHelper dataBase;

        public DbUpdate()
        {
            dataBase = new DbHelper();
        }

        public DbUpdate(DbHelper db)
        {
            dataBase = db;
        }

        public void Set(string name, object value)
        {
            sb.Append(",[" + name + "]=@" + name);
            DbParameter param = dataBase.Factory.CreateParameter();
            param.ParameterName = "@" + name;
            param.Value = value;
            pars.Add(param);
        }

        public int Execute(string tableName)
        {
            return dataBase.ExecuteNonQuery(
                "UPDATE [" + tableName + "] SET " + sb.ToString().TrimStart(','),
                pars.ToArray()
            );
        }

        public int Execute(string tableName, string appendSql, params DbParameter[] parameters)
        {
            pars.AddRange(parameters);
            return dataBase.ExecuteNonQuery(
                "UPDATE [" + tableName + "] SET " + sb.ToString().TrimStart(',') + " " + appendSql,
                pars.ToArray()
            );
        }
    }
}
