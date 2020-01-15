using System;
using System.Data.SqlClient;

namespace TransportSeed
{
    internal class Obrazenia : IInsertable
    {
        int Uraz;
        int Poszkodowany;
        public Obrazenia(int maxUraz, int maxPoszkodowany)
        {
            Random rnd = new Random();
            Uraz = rnd.Next(1, maxUraz);
            Poszkodowany = rnd.Next(1, maxPoszkodowany);
        }

        public SqlCommand GetAsInsert(SqlConnection conn)
        {
            string InsertSql = $"insert into Obrazenia(Id_Uraz, Id_Poszkodowany) VALUES({Uraz},{Poszkodowany})";
            return new SqlCommand(InsertSql, conn);
        }
    }
}