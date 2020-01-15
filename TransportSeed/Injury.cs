using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TransportSeed
{
    class Injury : IInsertable
    {
        string[] InjuryTypes = new string[] {
        "stłuczenie","rana otwarta","złamanie","skręcenie","zwichnięcie"
        };
        string Type;
        public Injury()
        {
            Random rnd = new Random();
            Type = InjuryTypes[rnd.Next(0, InjuryTypes.Length - 1)];
        }

        public SqlCommand GetAsInsert(SqlConnection conn)
        {
            string InsertSql = $"insert into Uraz(Rodzaj) VALUES('{Type}')";
            return new SqlCommand(InsertSql, conn);
        }
    }
}
