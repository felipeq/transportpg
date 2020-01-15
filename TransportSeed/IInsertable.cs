using System.Data.SqlClient;

namespace TransportSeed
{
    public interface IInsertable
    {
        public SqlCommand GetAsInsert(SqlConnection conn);
    }
}